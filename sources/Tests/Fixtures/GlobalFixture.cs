using Clients.QACandidatesClients;
using Microsoft.Extensions.DependencyInjection;
using Services.QACandidatesServices.Interfaces;

namespace Tests.Fixtures
{
    public class GlobalFixture
    {
        public IEnergyService EnergyService { get; }
        public IOrdersService OrdersService { get; }
        public IResetService ResetService { get; }
        public IBuyService BuyService { get; }

        public GlobalFixture()
        {
            var provider = ServiceProvider.Build();
            EnergyService = provider.GetRequiredService<IEnergyService>();
            OrdersService = provider.GetRequiredService<IOrdersService>();
            ResetService = provider.GetRequiredService<IResetService>();
            BuyService = provider.GetRequiredService<IBuyService>();
        }
    }

    [CollectionDefinition("Service Collection")]
    public class ServiceCollection : ICollectionFixture<GlobalFixture>
    {
    }
}
