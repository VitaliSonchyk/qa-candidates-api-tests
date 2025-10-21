using Clients.QACandidatesClients;
using Services.QACandidatesServices.Interfaces;

namespace Services.QACandidatesServices
{
    public class ResetService: IResetService
    {
        private readonly IResetClient _resetClient;
        public ResetService(IResetClient resetClient) => _resetClient = resetClient;

        public async Task ResetDataAsync() => await _resetClient.PostAsync();
    }
}
