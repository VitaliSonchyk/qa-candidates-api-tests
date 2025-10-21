using FluentAssertions;
using Services.QACandidatesServices.Interfaces;
using Tests.Fixtures;

namespace Tests
{
    [Collection("Service Collection")]
    public class OrdersTests
    {
        private readonly IOrdersService _ordersService;
        public OrdersTests(GlobalFixture globalFixture)
        {
            _ordersService = globalFixture.OrdersService;
        }

        [Fact(DisplayName = "Count of Orders before current date")]
        public async Task CountOrdersBeforeToday_ReturnsExpectedNumber()
        {
            var count = await _ordersService.GetCountBeforeTodayAsync();
            count.Should().BeGreaterThan(0);
        }
    }
}
