using FluentAssertions;
using Services.QACandidatesServices.Interfaces;
using Tests.Fixtures;

namespace Tests
{
    [Collection("Service Collection")]
    public class EnergyTests: IClassFixture<ClassFixture>
    {
        private readonly IEnergyService _energyService;

        public EnergyTests(GlobalFixture globalFixture)
        {
            _energyService = globalFixture.EnergyService;
        }

        [Fact]
        public async Task GetFuels_FuelsReturned()
        {
            var fuels = await _energyService.GetAllAsync();
            fuels.Should().NotBeNullOrEmpty("Fuels should return");
        }
    }
}
