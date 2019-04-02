using AcaDev.Persistance.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var entities = await dbContext.Set<TEntity>().AsQueryable().ToListAsync();
            if (entities == null || entities.Count == 0) return NotFound();

            return Ok(entities);
        }
    }
}
