using Clients.Contracts.Base;
using System.Text.Json.Serialization;

namespace Clients.Contracts.Orders
{
    public class OrdersRequestModel: IBaseModel
    {
        public int Quantity { get; set; }

        [JsonPropertyName("energy_id")]
        public int EnergyId {get;set; }
    }
}
