using System.Collections.Generic;

namespace TransportEnterprise.Models.Repositories
{
    public interface ICarParkRepository : IRepository<CarPark>
    {
        Coupling GetCouplingByProduct(Product product);
        ICollection<Coupling> GetAllPossibleCouplings();
        ICollection<Coupling> GetAllPossibleFullLoadedCouplings();
    }
}
