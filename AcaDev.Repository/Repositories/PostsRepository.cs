using AcaDev.Model.Entities;
using AcaDev.Repository.DbContexts;
using AcaDev.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaDev.Repository.Repositories
{
    public class PostsRepository : BaseRepository<Post>, IPostsRepository
    {
        public PostsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<Post> GetById(int id)
            => dbContext.Post
                .Where(a => a.Id == id)
                .Include(a => a.PostTags)
                .ThenInclude(a => a.Tag)
                .FirstOrDefaultAsync();

        public override IEnumerable<Post> GetAll()
            => dbContext.Post
                .Include(a => a.PostTags)
                .ThenInclude(a => a.Tag)
                .AsEnumerable();

        public Task<Post> GetWithComments(int id) 
            => dbContext.Post.Include(a => a.Comments).FirstAsync(a => a.Id == id);
    }
}
