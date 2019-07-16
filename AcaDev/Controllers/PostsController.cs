using AcaDev.Attribute;
using AcaDev.Domain.Entities;
using AcaDev.Domain.Services;
using AcaDev.Dtos;
using AcaDev.Persistance.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AcaDev.Controllers
{
    public class PostsController : BaseController<Post>
    {
        private readonly IPostService postService;

        public PostsController(AppDbContext dbContext, IPostService postService) : base(dbContext)
        {
            this.postService = postService;
        }

        public override async Task<IActionResult> All()
        {
            var entities = await dbContext.Post
                .Include(a => a.Author)
                .Include(a => a.PostTags).ThenInclude(a => a.Tag)
                .Select(a => new PostDto
                {
                    Title = a.Title,
                    Author = a.Author.Name,
                    Content = a.Content,
                    PublishDate = a.PublishDate,
                    Tags = a.PostTags.Select(b => b.Tag.Name).ToList()
                })
                .ToArrayAsync();

            if (entities == null || entities.Length == 0) return NotFound();

            return Ok(entities);
        }

        [HttpGet]
        [ExactQueryParam("title")]
        public async Task<IActionResult> GetByTitle([FromQuery] string title)
        {
            var post = await dbContext.Post
                .Where(a => postService.TitleToUrlTitle(a.Title) == title.ToLower())
                .Include(a => a.Author)
                .Include(a => a.Comments)
                .Include(a => a.PostTags).ThenInclude(a => a.Tag)
                .Select(a => new PostDto
                {
                    Title = a.Title,
                    Author = a.Author.Name,
                    Content = a.Content,
                    PublishDate = a.PublishDate,
                    Tags = a.PostTags.Select(b => b.Tag.Name).ToList(),
                    Comments = a.Comments
                })
                .FirstOrDefaultAsync();

            if (post == null) return NotFound();

            return Ok(post);
        }
    }
}