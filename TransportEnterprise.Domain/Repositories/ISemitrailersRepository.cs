using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models.Repositories
{
    public interface ISemitrailersRepository<T> : IRepository<T> where T: Semitrailer<Product>
    {
        ICollection<T> GetByType(Type semitrailerType);
        T FindByPattern(T pattern);
    }
}
