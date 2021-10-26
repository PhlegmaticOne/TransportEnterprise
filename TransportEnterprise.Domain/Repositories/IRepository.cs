using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportEnterprise.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task<T> Load();
    }
}
