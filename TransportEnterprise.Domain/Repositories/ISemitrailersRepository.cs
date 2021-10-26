using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransportEnterprise.Models.Repositories
{
    public interface ISemitrailersRepository<T> : IRepository<T> where T: Semitrailer<Product>
    {
        Task<ICollection<T>> GetByTypeAsync(Type semitrailerType);
        Task<T> FindByPatternAsync(T pattern);
    }
}
