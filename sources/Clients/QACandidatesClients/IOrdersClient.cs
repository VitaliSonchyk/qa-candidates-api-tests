using Clients.Contracts.Common;
using Clients.Contracts.Orders;
using Core.Common.Refit;
using Refit;

namespace Clients.QACandidatesClients
{
    public interface IOrdersClient : IRefitClient
    {
        [Get("/ENSEK/orders")]
        Task<IEnumerable<OrdersResponseModel>> GetAsync();

        [Put("/ENSEK/orders/{orderId}")]
        Task<ResponseMessageModel> PatchAsync(string orderId, OrdersRequestModel model);
    }
}
