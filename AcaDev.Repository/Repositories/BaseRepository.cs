using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaDev.Repository.DbContexts;
using AcaDev.Repository.Repositories.Interfaces;

namespace AcaDev.Repository.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected AppDbContext dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Add(T entity) => dbContext.Set<T>().AddAsync(entity);
        public Task<T> GetById(int id) => dbContext.Set<T>().FindAsync(id);
        public IEnumerable<T> GetAll() => dbContext.Set<T>().AsEnumerable();
        public void Delete(T entity) => dbContext.Remove(entity);
        public Task Save() => dbContext.SaveChangesAsync();
    }
}
