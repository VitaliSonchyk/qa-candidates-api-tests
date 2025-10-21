using Clients.QACandidatesClients;
using Serilog;
using Services.QACandidatesServices.Interfaces;
using System.Text.RegularExpressions;

namespace Services.QACandidatesServices
{
    public class BuyService : IBuyService
    {
        private readonly IBuyClient _buyClient;
        public BuyService(IBuyClient buyClient) => _buyClient = buyClient;

        public async Task<string> BuyEnergyAsync(string energyId, int quantity)
        {
            Log.Information($"Buy <{energyId}> energy. Quantity <{quantity}>");
            var response = await _buyClient.PutAsync(energyId, quantity);
            var orderId = Regex.Match(response.Message, @"is ([0-9a-f\-]{36})").Groups[1].Value.ToString();
            return orderId;
        }
    }
}
