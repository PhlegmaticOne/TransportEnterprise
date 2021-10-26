using System.Collections.Generic;

namespace TransportEnterprise.Models.Repositories
{
    public interface IRepository<T> where T : BaseDomainModel
    {
        void Add(T entity);
        LoadingResult<T> Load(int id);
        ICollection<T> LoadAll();
        void Update(int id, T newEntity);
    }
}
