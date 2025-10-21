using Clients.Contracts.Builders.Base;
using Clients.Contracts.Orders;
using FizzWare.NBuilder;

namespace Clients.Contracts.Builders
{
    public class OrdersRequestModelBuilder: BaseModelBuilder<OrdersRequestModel>
    {
        public OrdersRequestModelBuilder WithRandomPatch(string orderId)
        {
             Builder
                .With(x => x.Quantity = new RandomGenerator().Next(1, 100))
                .With(x => x.EnergyId = new RandomGenerator().Next(1, 100));
            return this;
        }
    }
}
