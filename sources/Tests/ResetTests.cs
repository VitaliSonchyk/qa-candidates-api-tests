using Clients.Contracts.Builders;
using Clients.Contracts.Builders.Base;
using FizzWare.NBuilder;
using FluentAssertions;
using Services.QACandidatesServices;
using Services.QACandidatesServices.Interfaces;
using System.ComponentModel.DataAnnotations;
using Tests.Fixtures;

namespace Tests
{
    [Collection("Service Collection")]
    public class ResetTests
    {
        private readonly IOrdersService _ordersService;
        private readonly IResetService _resetService;
        public ResetTests(GlobalFixture globalFixture)
        {
            _ordersService = globalFixture.OrdersService;
            _resetService = globalFixture.ResetService;
        }

        [Fact(DisplayName = "Reset Test data")]
        public async Task ResetData_ResetToInternalState()
        {
            var existingOrder = await _ordersService.GetRandomExistingOrderAsync();
            var patchModel = BuilderFactory<OrdersRequestModelBuilder>.Instance.With(x => x.Quantity = new RandomGenerator().Next(1, 100)).Build();
            await _ordersService.UpdateAsync(existingOrder.Id, patchModel);
            var updatedOrder = await _ordersService.GetOrderByIdAsync(existingOrder.Id);
            updatedOrder.Quantity.Should().Be(patchModel.Quantity, "Order should be updated before reset!");

            await _resetService.ResetDataAsync();

            updatedOrder = await _ordersService.GetOrderByIdAsync(existingOrder.Id);
            updatedOrder.Quantity.Should().NotBe(patchModel.Quantity, "Order should be reverted after reset!");
        }
    }
}
