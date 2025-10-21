using Clients.Contracts.Base;

namespace Clients.Contracts.Common
{
    public class ResponseMessageModel: IBaseModel
    {
        public string Message { get; set; }
    }
}
