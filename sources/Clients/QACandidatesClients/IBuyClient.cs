using Clients.Contracts.Common;
using Refit;

namespace Clients.QACandidatesClients
{
    public interface IBuyClient: IResetClient
    {
        [Put("/ENSEK/buy/{id}/{quantity}")]
        Task<ResponseMessageModel> PutAsync(string id, int quantity);
    }
}
