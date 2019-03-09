using AcaDev.Model.Entities;
using AcaDev.Model.IRepository;
using AcaDev.Repository.DbContexts;

namespace AcaDev.Repository.Repositories
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
