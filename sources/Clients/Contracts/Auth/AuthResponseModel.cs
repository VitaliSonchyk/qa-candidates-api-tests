using Clients.Contracts.Base;
using System.Text.Json.Serialization;

namespace Clients.Contracts.Auth
{
    public class AuthResponseModel: IBaseModel
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}
