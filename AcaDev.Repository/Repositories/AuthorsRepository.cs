using AcaDev.Model.Entities;
using AcaDev.Model.IRepository;
using AcaDev.Repository.DbContexts;

namespace AcaDev.Repository.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
