using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcaDev.Repository.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        Task Save();
    }
}
