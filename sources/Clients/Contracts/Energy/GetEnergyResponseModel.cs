namespace Clients.Contracts.Energy
{
    public class GetEnergyResponseModel
    {
        public EnergyModel Electric { get; set; }
        public EnergyModel Gas { get; set; }
        public EnergyModel Nuclear { get; set; }
        public EnergyModel Oil { get; set; }
    }
}
