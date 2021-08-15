using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.ResourcesReader.Message;

namespace SharedKernal.Middlewares.Basees
{
    public class BaseRequestValidator<TEntity> : AbstractValidator<BaseRequestDto<TEntity>>
    {
        public IMessageResourceReader MessageResource => Engine.Container.GetRequiredService<IMessageResourceReader>();

        public BaseRequestValidator()
        {
            RuleFor(obj => obj.Data).NotNull().WithMessage(MessageResource.GetMessage(messageKey: "test_key"));
        }
    }
}
