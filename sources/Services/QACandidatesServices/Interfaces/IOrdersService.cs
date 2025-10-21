using Clients.Contracts.Orders;

namespace Services.QACandidatesServices.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersResponseModel>> GetAllAsync();
        Task<OrdersResponseModel> GetOrderByIdAsync(string id);
        Task<int> GetCountBeforeTodayAsync();
        Task<IEnumerable<OrdersResponseModel>> GetOrdersByQuantityFuelAsync(string fuel, int quantity);
        Task<OrdersResponseModel> GetRandomExistingOrderAsync();
        Task UpdateAsync(string orderId, OrdersRequestModel model);
    }
}

