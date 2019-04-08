using AcaDev.Attribute;
using AcaDev.Domain.Entities;
using AcaDev.Persistance.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AcaDev.Controllers
{
    public class PostsController : BaseController<Post>
    {
        public PostsController(AppDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet]
        [ExactQueryParam("title")]
        public async Task<IActionResult> GetByTitle([FromQuery] string title)
        {
            var post = await dbContext.Post.Where(a => a.Title == title).FirstOrDefaultAsync();
            if (post == null) return NotFound();

            return Ok(post);
        }
    }
}
