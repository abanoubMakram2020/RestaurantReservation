using SharedKernal.Core.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Core.Common.Common
{
    public class SendEmail
    {

        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        //static SendEmail()
        //{
        //    GmailHost = "smtp.gmail.com";
        //    GmailPort = 587; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
        //    GmailSSL = true;
        //}

        public void Send()
        {
            SmtpClient smtp = new SmtpClient(EmailSettings.GmailHost, EmailSettings.GmailPort);

            //smtp.GmailUsername = "grainstoresystem@gmail.com";
            //smtp.GmailPassword = "Ab@123456";

            //smtp.Host = EmailSettings.GmailHost;
            //smtp.Port = EmailSettings.GmailPort;
            smtp.EnableSsl = EmailSettings.GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(EmailSettings.EmailAddress, EmailSettings.GmailPassword);

            using (var message = new MailMessage(EmailSettings.EmailAddress, this.ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                smtp.Send(message);
            }
        }
    }
}
