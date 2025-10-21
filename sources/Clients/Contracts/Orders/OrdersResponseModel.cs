using Core.Converters;
using System.Text.Json.Serialization;

namespace Clients.Contracts.Orders
{
    public class OrdersResponseModel
    {
        public string Fuel { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        [JsonConverter(typeof(Rfc1123DateTimeConverter))]
        public DateTime Time { get; set; }
    }
}
