using Clients.Contracts.Energy;
using Clients.QACandidatesClients;
using Core.Extensions;
using Serilog;
using Services.QACandidatesServices.Interfaces;

namespace Services.QACandidatesServices
{
    public class EnergyService : IEnergyService
    {
        private readonly IEnergyClient _energyClient;
        public EnergyService(IEnergyClient energyClient) => _energyClient = energyClient;

        public async Task<EnergyModel> GetFuelAsync(string fuel)
        {
            Log.Information($"Retrieving energy for fuel: <{fuel}>");
            var allEnergies = await GetAllAsync();
            return allEnergies.GetValue(fuel);
        }

        public async Task<IDictionary<string, EnergyModel>> GetAllAsync()
        {
            Log.Information("Retrieving the list of energies");
            return await _energyClient.GetAsync();
        }
    }
}
