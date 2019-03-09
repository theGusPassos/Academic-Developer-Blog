using AcaDev.Model.Entities;
using AcaDev.Model.IService;
using AcaDev.Repository.Repositories.Interfaces;
using AcaDev.Shared;
using System.Threading.Tasks;

namespace AcaDev.Model.Services
{
    public class PostsService : BaseService<Post>, IPostsService
    {   
        public PostsService(IPostsRepository repository) : base(repository)
        {
        }

        public async Task<Result<Post>> GetWithComments(int id)
        {
            return null;
        }
    }
}
