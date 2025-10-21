namespace Services.QACandidatesServices.Interfaces
{
    public interface IBuyService
    {
        Task<string> BuyEnergyAsync(string energyId, int quantity);
    }
}
