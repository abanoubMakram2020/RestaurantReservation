using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.ServicesInterfaces;
using RestaurantReservation.Application.UnitOfWorkInterface;
using RestaurantReservation.Domain.Models;
using SharedKernal.Core.Common.Common;
using SharedKernal.Core.Common.Configuration;
using SharedKernal.Core.Common.Enum;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.JWTSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
//using SharedKernal.Core.Common.Configuration;

namespace RestaurantReservation.Application.Services
{
    public class AccountService : IAccountService
    {
        #region Fielsa
        private readonly UserManager<User> _user;
        private readonly IMapper _autoMapper;
        private readonly IJWTTokenHandler _tokenHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion



        #region CTOR
        public AccountService(UserManager<User> user,
            IMapper autoMapper,
            IJWTTokenHandler tokenHandler,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _user = user;
            _autoMapper = autoMapper;
            _tokenHandler = tokenHandler;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Actions
        public async Task<ResponseResultDto<TokenDTO>> Login(BaseRequestDto<UserDTO> userDTO)
        {

            var claims = _tokenHandler.GetTokenData(_httpContextAccessor.HttpContext.Request);
            if (claims != null && claims.Any())
            {
                return ResponseResultDto<TokenDTO>.MultiError(null, "you already authrized");
            }
            else
            {
                TokenDTO tokenDTO = new TokenDTO();
                var user = await _user.FindByEmailAsync(email: userDTO.Data.Email);
                if (user != null)
                {
                    PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
                    var result = _passwordHasher.VerifyHashedPassword(user: user, hashedPassword: user.PasswordHash, providedPassword: userDTO.Data.Password);
                    if (result == PasswordVerificationResult.Success)
                    {
                        // await _signInManager.SignInAsync(user, true);
                        List<UserClaim> userClaims = new List<UserClaim>()
                    {
                        new UserClaim { Name = SecurityEnum.TokenInfo.UserId, Value = user.Id.ToString() },
                        new UserClaim{Name=SecurityEnum.TokenInfo.UserName,Value=user.UserName },
                        new UserClaim{Name=SecurityEnum.TokenInfo.UserEmail,Value=user.Email }
                    };

                        tokenDTO.Token = _tokenHandler.CreateToken(userClaims, SecurityEnum.Audiance.Web);
                        // tokenDTO.Token = _tokenHandler.(userClaims, SecurityEnum.Audiance.Web);
                    }
                }
                if (!string.IsNullOrEmpty(tokenDTO.Token))
                    return ResponseResultDto<TokenDTO>.Success(tokenDTO, "Success");
                return ResponseResultDto<TokenDTO>.NotFound(null, "Failed");
            }
        }

        //public async Task<ResponseResultDto<bool>> RefresToken(BaseRequestDto<int> userRegistrationDTO)
        //{
        //    //User userObj = new User();

        //    //userObj = _autoMapper.Map<User>(userRegistrationDTO.Data);

        //    //await _user.CreateAsync(userObj);

        //    //return ResponseResultDto<bool>.Success(await _unitOfWork.Complete() > 0, " done");
        //}

        public async Task<ResponseResultDto<string>> Register(BaseRequestDto<UserRegistrationDTO> userRegistrationDTO)
        {

            var claims = _tokenHandler.GetTokenData(_httpContextAccessor.HttpContext.Request);
            if (claims != null && claims.Any())
            {
                return ResponseResultDto<string>.MultiError(null, "you already authrized");
            }
            else
            {
                User userObj = new User();

                userObj = _autoMapper.Map<User>(userRegistrationDTO.Data);
                userObj.Id = Guid.NewGuid().ToString();
                //userObj.EmailConfirmed = true;
                var result = await _user.CreateAsync(user: userObj, password: userRegistrationDTO.Data.Password);
                if (!result.Succeeded)
                    return ResponseResultDto<string>.MultiError("faild", string.Join(", ", result.Errors.FirstOrDefault().Description));

                string verftToken = CreateEmailVerficationToken(Guid.Parse(userObj.Id));
                //string emailBody = "Welcom " + userObj.UserName + " Kindly Verify Your Email <a href='www.google.com?q=" + verftToken + "'>verfiy</a>";
                //string subject = "Vefication Your Email";
                //bool sendEmailResult = await SendEMail(new[] { userObj.Email }, null, null, emailBody, subject, null, null);
                ////SendEmailToVerfication(userObj.Email, "Vefication Your Email", "Welcom " + userObj.UserName + " Kindly Verify Your Email <a href='www.google.com?q=" + verftToken + "'>verfiy</a>");
                //if (!sendEmailResult)
                //    return ResponseResultDto<bool>.MultiError(false, "Send Email Faild");


                // return ResponseResultDto<bool>.Success(true, " Email Sent");
                return ResponseResultDto<string>.Success(verftToken, " Email Sent");
            }
        }

        public async Task<ResponseResultDto<bool>> Verification(BaseRequestDto<string> token)
        {
            byte[] data = Convert.FromBase64String(token.Data);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));

            byte[] key = data.Skip(8).Take(16).ToArray();
            Guid userId = new Guid(key);

            if (when < DateTime.UtcNow.AddHours(-24))
                return ResponseResultDto<bool>.InvalidData(false, "Your Token Not Valid, Kindly Resend");

            var user = await _user.FindByIdAsync(userId.ToString());
            if (user == null)
                return ResponseResultDto<bool>.NotFound(false, "user not exist");
            user.EmailConfirmed = true;
            var updateResult = await _user.UpdateAsync(user);

            return ResponseResultDto<bool>.Success(true, "Success");

        }

        public async Task<ResponseResultDto<string>> ResendEmailVerficationToken(BaseRequestDto<string> email)
        {
            var user = await _user.FindByEmailAsync(email: email.Data);
            if (user == null)
                return ResponseResultDto<string>.NotFound("Failed", "Email Not Exist");

            string verftToken = CreateEmailVerficationToken(Guid.Parse(user.Id));
            //string emailBody = "Welcom " + user.UserName + " Kindly Verify Your Email <a href='www.google.com?q=" + verftToken + "'>verfiy</a>";
            //string subject = "Vefication Your Email";
            // bool sendEmailResult =await SendEMail(new[] { user.Email }, null, null, emailBody, subject, null, null);
            // SendEmailToVerfication(user.Email, "Vefication Your Email", "Welcom " + user.UserName + " Kindly Verify Your Email <a href='www.google.com?q=" + verftToken + "'>verfiy</a>");
            //if (!sendEmailResult)
            //    return ResponseResultDto<string>.MultiError("failed", "Send Email Faild");

            return ResponseResultDto<string>.Success(verftToken, " Email Sent");
        }

        public async Task<ResponseResultDto<bool>> ForgetPassword(BaseRequestDto<UserRegistrationDTO> user)
        {

            var userObj = await _user.FindByEmailAsync(email: user.Data.Email);
            if (userObj == null)
                return ResponseResultDto<bool>.NotFound(false, "Email Not Exist");

            var newHashedpassword = _user.PasswordHasher.HashPassword(userObj, user.Data.Password);
            userObj.PasswordHash = newHashedpassword;
            var updateResult = await _user.UpdateAsync(user: userObj);
            if (!updateResult.Succeeded)
                return ResponseResultDto<bool>.InvalidData(false, "Update Password Failed" + updateResult.Errors.FirstOrDefault().Description);
            return ResponseResultDto<bool>.Success(true, "Success");
        }

        #endregion


        #region Methods
        public bool SendEmailToVerfication(string toEmail, string subject, string body)
        {
            try
            {
                SendEmail mailer = new SendEmail();
                mailer.ToEmail = toEmail;
                mailer.Subject = subject;
                mailer.Body = body;
                mailer.IsHtml = true;
                mailer.Send();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private string CreateEmailVerficationToken(Guid userId)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = userId.ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        public async Task<bool> SendEMail(string[] to, string[] cc, string[] bcc, string body, string subject, string[] replytoemails, string sendertitle)
        {
            try
            {


                MailMessage message = new MailMessage
                {
                    From = new MailAddress(address: EmailSettings.EmailAddress, displayName: sendertitle),
                    Priority = MailPriority.High,
                    Subject = subject,
                    SubjectEncoding = Encoding.UTF8,
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8,
                    Body = body,
                };

                if (to != null)
                    foreach (var e in to)
                    {
                        message.To.Add(new MailAddress(e));
                    }

                if (cc != null)
                    foreach (var c in cc)
                        message.CC.Add(new MailAddress(c));

                if (bcc != null)
                    foreach (var bc in bcc)
                        message.Bcc.Add(new MailAddress(bc));

                if (replytoemails != null)
                    foreach (var e in replytoemails)
                        message.ReplyToList.Add(e);

                NetworkCredential MyCredential = new NetworkCredential(userName: EmailSettings.EmailAddress,
                                                                       password: EmailSettings.GmailPassword);
                SmtpClient mailing = new SmtpClient(host: EmailSettings.GmailHost,
                                                    port: EmailSettings.GmailPort)
                {
                    EnableSsl = EmailSettings.GmailSSL,
                    UseDefaultCredentials = true,
                    Credentials = MyCredential,
                };

                mailing.Send(message);
                return true;
            }
            catch (SmtpFailedRecipientException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

    }
}

