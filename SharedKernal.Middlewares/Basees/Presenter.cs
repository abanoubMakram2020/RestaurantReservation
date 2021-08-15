using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Middlewares.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.Basees
{
    public sealed class Presenter
    {
        #region Properties
        public ContentResult ContentResult { get; }
        #endregion

        #region Constructor
        public Presenter()
        {
            ContentResult = new ContentResult
            {
                ContentType = "application/json"
            };
        }
        #endregion

        #region Methods
        public async Task<ContentResult> Handle<TRequest, TResponse>(Func<BaseRequestDto<TRequest>, Task<ResponseResultDto<TResponse>>> serviceRequest, BaseRequestDto<TRequest> request)
        {
            ValidationResult validationResult = ValidateRequestDto(request);
            ResponseResultDto<TResponse> response = new ResponseResultDto<TResponse>();
            if (validationResult.IsValid)
            {
                response = await serviceRequest.Invoke(request);
                if (response != null)
                {
                    ContentResult.StatusCode = (int)HttpStatusCode.OK;
                    ContentResult.Content = JsonHandler.Serialize(response);
                }
            }
            else
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                validationResult.Errors.GroupBy(p => p.PropertyName).ToList().ForEach(item => dict.Add(item.Key, item.Select(e => e.ErrorMessage).ToList()));
                ResponseResultDto<Dictionary<string, List<string>>>.InvalidData(dict, Guid.NewGuid().ToString());
                ContentResult.StatusCode = (int)HttpStatusCode.BadRequest;
                ContentResult.Content = JsonHandler.Serialize(dict);
                return ContentResult;
            }
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }
        #endregion

        #region Private - Methods
        /// <summary>
        /// Validate API request input dto.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request">request input.</param>
        /// <returns>ValidationResult</returns>
        private ValidationResult ValidateRequestDto<TRequest>(BaseRequestDto<TRequest> request)
        {
            ValidationResult results = new ValidationResult();
            IValidator<BaseRequestDto<TRequest>> baseValidator = new BaseRequestValidator<TRequest>();
            results = baseValidator.Validate(request);
            if (results.IsValid)
            {
                Type customValidator = System.Reflection.Assembly.Load(typeof(TRequest).Assembly.GetName()).GetTypes().Where(x => x.IsSubclassOf(typeof(AbstractValidator<TRequest>))).FirstOrDefault();
                if (customValidator != null)
                {
                    IValidator<TRequest> innerDataValidator = (IValidator<TRequest>)Activator.CreateInstance(customValidator);
                    results = innerDataValidator.Validate(request.Data);
                }
            }
            return results;
        }
        #endregion
    }
}
