using Clients.Contracts.Energy;

namespace Services.QACandidatesServices.Interfaces
{
    public interface IEnergyService
    {
        Task<IDictionary<string, EnergyModel>> GetAllAsync();
        Task<EnergyModel> GetFuelAsync(string fuel);
    }
}

