using Clients.Contracts.Auth;
using Core.Common.Refit;
using Refit;

namespace Clients.QACandidatesClients
{
    public interface ILoginClient : IRefitClient
    {
        [Post("/ENSEK/login")]
        Task<AuthResponseModel> PostAsync([Body] AuthRequestModel model);
    }
}
