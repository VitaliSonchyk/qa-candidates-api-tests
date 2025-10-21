using FluentAssertions;
using FluentAssertions.Execution;
using Services.QACandidatesServices;
using Services.QACandidatesServices.Interfaces;
using Tests.Fixtures;

namespace Tests
{
    [Collection("Service Collection")]
    public class BuyTests
    {
        private readonly IBuyService _buyService;
        private readonly IEnergyService _energyService;
        private readonly IOrdersService _ordersService;
        public BuyTests(GlobalFixture globalFixture)
        {
            _buyService = globalFixture.BuyService;
            _energyService = globalFixture.EnergyService;
            _ordersService = globalFixture.OrdersService;
        }

        [Theory]
        [InlineData("electric")]
        [InlineData("gas")]
        [InlineData("nuclear")]
        [InlineData("oil")]
        public async Task BuyFuel_OrdersUpdated(string fuel)
        {
            var fuelData = await _energyService.GetFuelAsync(fuel);
            var orderId = await _buyService.BuyEnergyAsync(fuelData.EnergyId.ToString(), fuelData.QuantityOfUnits);

            var createdOrder = await _ordersService.GetOrderByIdAsync(orderId);
            using (new AssertionScope())
            {
                createdOrder.Quantity.Should().Be(fuelData.QuantityOfUnits, "Order quantity should match the bought quantity!");
                createdOrder.Fuel.Should().Be(fuel, "Order fuel should match the bought fuel!");
            }
        }
    }
}
