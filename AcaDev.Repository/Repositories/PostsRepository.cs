using AcaDev.Model.Entities;
using AcaDev.Repository.DbContexts;
using AcaDev.Repository.Repositories.Interfaces;

namespace AcaDev.Repository.Repositories
{
    public class PostsRepository : BaseRepository<Post>, IPostsRepository
    {
        public PostsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
