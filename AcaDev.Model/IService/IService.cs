using AcaDev.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcaDev.Model.IService
{
    public interface IService<T>
    {
        Task<Result<T>> GetById(int id);
        Task<Result<List<T>>> GetAll();
        Task<Result> Delete(int id);
    }
}
