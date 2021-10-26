using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransportEnterprise.Models.Repositories
{
    public interface ICarParkRepository : IRepository<CarPark>
    {
        Task<Coupling> GetCouplingByProduct(Product product);
        Task<ICollection<Coupling>> GetAllPossibleCouplings();
        Task<ICollection<Coupling>> GetAllPossibleFullLoadedCouplings();
    }
}
