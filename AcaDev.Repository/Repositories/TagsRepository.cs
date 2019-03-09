using AcaDev.Model.Entities;
using AcaDev.Model.IRepository;
using AcaDev.Repository.DbContexts;

namespace AcaDev.Repository.Repositories
{
    public class TagsRepository : BaseRepository<Tag>, ITagsRepository
    {
        public TagsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
