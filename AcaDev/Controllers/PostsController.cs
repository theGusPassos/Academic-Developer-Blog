using AcaDev.Attribute;
using AcaDev.Domain.Entities;
using AcaDev.Persistance.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
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
            var post = await dbContext.Post
                // Removes dots to avoid problems in the URL generation
                .Where(a => a.Title.ToLower().Replace(".", string.Empty).Replace(" ", string.Empty) == title.ToLower())
                .FirstOrDefaultAsync();

            if (post == null) return NotFound();

            return Ok(post);
        }
    }
}