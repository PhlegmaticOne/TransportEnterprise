using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransportEnterprise.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<T> LoadAsync(int id);
        Task<ICollection<T>> LoadAllAsync();
        Task SaveAsync();
        Task UpdateAsync(int id, T newEntity);
    }
}
