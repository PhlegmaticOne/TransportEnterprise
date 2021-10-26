namespace TransportEnterprise.Models.Repositories
{
    public interface ITruckTracktorsRepository<T> : IRepository<T> where T: TruckTractor
    {
        T GetWithMaxPetrolWaste();
    }
}
