using Clients.Contracts.Auth;
using Clients.Contracts.Builders.Auth;
using Clients.QACandidatesClients;
using Core.Configuration;
using Services.QACandidatesServices.Interfaces;

namespace Services.QACandidatesServices
{
    public class LoginService : ILoginService
    {
        private readonly ILoginClient _loginClient;
        private Config _config;
        public LoginService(ILoginClient loginClient, Config config)
        {
            _loginClient = loginClient;
            _config = config;
        }

        public async Task<AuthResponseModel> LoginAsync(string userName, string password) =>
            await _loginClient.PostAsync(AuthRequestModelBuilder.Instance.WithCreds(userName, password).Build());

        public async Task<AuthResponseModel> LoginAsync() =>
            await _loginClient.PostAsync(AuthRequestModelBuilder.Instance.WithCreds(_config.UserName, _config.Password).Build());
    }
}
