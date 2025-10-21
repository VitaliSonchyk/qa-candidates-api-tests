using Clients.Contracts.Auth;

namespace Services.QACandidatesServices.Interfaces
{
    public interface ILoginService
    {
        Task<AuthResponseModel> LoginAsync(string userName, string password);
        Task<AuthResponseModel> LoginAsync();
    }
}
