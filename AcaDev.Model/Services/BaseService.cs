using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaDev.Model.IService;
using AcaDev.Repository.Repositories.Interfaces;
using AcaDev.Shared;
using Microsoft.EntityFrameworkCore;

namespace AcaDev.Model.Services
{
    public class BaseService<T> : IService<T>
    {
        protected readonly IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<T>> GetById(int id)
        {
            var entity = await repository.GetById(id);
            if (entity != null)
            {
                return Result.Ok(entity);
            }

            return Result.Fail<T>("Entity not found", ResultCode.NotFound);
        }

        public async Task<Result<List<T>>> GetAll()
        {
            var entities = await repository.GetAll().AsQueryable().ToListAsync();
            if (entities.Count > 0)
            {
                return Result.Ok(entities);
            }

            return Result.Fail<List<T>>("no entity found", ResultCode.NotFound);
        }

        public async Task<Result> Delete(int id)
        {
            var entity = await repository.GetById(id);
            if (entity != null)
            {
                repository.Delete(entity);
                return Result.Ok();
            }

            return Result.Fail<T>("Entity not found", ResultCode.NotFound);
        }
    }
}
