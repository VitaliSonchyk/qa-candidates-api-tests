using System.Threading.Tasks;
using Clients.Contracts.Energy;
using Core.Common.Refit;
using Refit;

namespace Clients.QACandidatesClients
{
    public interface IEnergyClient : IRefitClient
    {
        [Get("/ENSEK/energy")]
        Task<IDictionary<string, EnergyModel>> GetAsync();
    }
}


