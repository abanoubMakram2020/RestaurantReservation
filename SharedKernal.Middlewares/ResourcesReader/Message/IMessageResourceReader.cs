using SharedKernal.Core.Common.Enum;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public interface IMessageResourceReader
    {
        string GetMessage(HttpEnum.ResponseStatusCode responseStatus);
        string GetMessage(string messageKey);
    }
}
