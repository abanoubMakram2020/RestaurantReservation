using SharedKernal.Core.Common.Enum;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public class MessageResourceReader : FileReader, IMessageResourceReader
    {
        public MessageResourceReader() : base(ResourceEnum.LocalizationType.Message)
        {
        }
        public string GetMessage(HttpEnum.ResponseStatusCode responseStatus) => GetKeyValue(key: responseStatus.ToString());

        public string GetMessage(string messageKey) => GetKeyValue(key: messageKey);
    }
}
