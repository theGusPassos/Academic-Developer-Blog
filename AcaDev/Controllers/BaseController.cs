using AcaDev.Persistance.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaDev.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BaseController<TEntity> : Controller 
        where TEntity : class
    {
        protected AppDbContext dbContext;

        public BaseController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TEntity> Get(int id) =>
            dbContext.Set<TEntity>().FindAsync(id);


        [HttpGet]
        public Task<List<TEntity>> All() =>
            dbContext.Set<TEntity>().AsQueryable().ToListAsync();
    }
}
