using AcaDev.Model.Entities;
using AcaDev.Repository.DbContexts;
using AcaDev.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AcaDev.Repository.Repositories
{
    public class PostsRepository : BaseRepository<Post>, IPostsRepository
    {
        public PostsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Post> GetWithComments(int id) 
            => dbContext.Post.Include(a => a.Comments).FirstAsync(a => a.Id == id);
    }
}
