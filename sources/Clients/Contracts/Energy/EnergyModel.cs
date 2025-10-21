using System.Text.Json.Serialization;

namespace Clients.Contracts.Energy
{
    public class EnergyModel
    {
        [JsonPropertyName("energy_id")]
        public int EnergyId { get; set; }
        [JsonPropertyName("price_per_unit")]
        public double PricePerUnit { get; set; }
        [JsonPropertyName("quantity_of_units")]
        public int QuantityOfUnits { get; set; }
        [JsonPropertyName("unit_type")]
        public string UnitType { get; set; }
    }
}
