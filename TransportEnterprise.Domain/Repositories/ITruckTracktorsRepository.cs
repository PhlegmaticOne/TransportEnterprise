using System.Threading.Tasks;

namespace TransportEnterprise.Models.Repositories
{
    public interface ITruckTracktorsRepository<T> : IRepository<T> where T: TruckTractor
    {
        Task<T> GetWithMaxPetrolWaste();
    }
}
