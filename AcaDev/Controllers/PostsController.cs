using AcaDev.Domain.Entities;
using AcaDev.Persistance.DbContexts;

namespace AcaDev.Controllers
{
    public class PostsController : BaseController<Post>
    {
        public PostsController(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
