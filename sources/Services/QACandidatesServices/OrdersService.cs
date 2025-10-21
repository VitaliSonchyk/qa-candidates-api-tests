using Clients.Contracts.Orders;
using Clients.QACandidatesClients;
using FizzWare.NBuilder;
using Serilog;
using Services.QACandidatesServices.Interfaces;

namespace Services.QACandidatesServices
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersClient _ordersClient;
        public OrdersService(IOrdersClient ordersClient) => _ordersClient = ordersClient;

        public async Task<OrdersResponseModel> GetOrderByIdAsync(string id)
        {
            Log.Information($"Retrieving order by Id: <{id}>");
            return (await GetOrders(x => x.Id == id)).FirstOrDefault() ?? throw new ArgumentException($"Order with Id: {id} not found!");
        }

        public async Task<IEnumerable<OrdersResponseModel>> GetOrdersByQuantityFuelAsync(string fuel, int quantity) 
        {
            Log.Information($"Retrieving list of orders by filter: <{nameof(fuel)}> = <{fuel}>; <{nameof(quantity)}> = <{quantity}>");
            return await GetOrders(x => x.Fuel == fuel && x.Quantity == quantity);
        }

        public async Task<IEnumerable<OrdersResponseModel>> GetAllAsync() => await _ordersClient.GetAsync();

        public async Task<int> GetCountBeforeTodayAsync()
        {
            var orders = await GetOrders(x => x.Time < DateTime.UtcNow);
            return orders.Count();
        }

        public async Task<OrdersResponseModel> GetRandomExistingOrderAsync()
        {
            var allOrders = await _ordersClient.GetAsync();
            return allOrders.ElementAt(new RandomGenerator().Next(0, allOrders.Count() - 1));
        }

        public async Task UpdateAsync(string orderId, OrdersRequestModel model) => await _ordersClient.PatchAsync(orderId, model);

        private async Task<IEnumerable<OrdersResponseModel>> GetOrders(Func<OrdersResponseModel, bool> func)
        {
            var allOrders = await _ordersClient.GetAsync();
            var filteredOrders = allOrders.Where(x => func(x));
            return filteredOrders;
        }
    }
}
