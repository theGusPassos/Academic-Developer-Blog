using AcaDev.Model.Entities;
using AcaDev.Model.IService;
using AcaDev.Repository.Repositories.Interfaces;
using AcaDev.Shared;
using System.Threading.Tasks;

namespace AcaDev.Model.Services
{
    public class PostsService : BaseService<Post, IPostsRepository>, IPostsService
    {   
        public PostsService(IPostsRepository repository) : base(repository)
        {
        }

        public async Task<Result<Post>> GetWithComments(int id)
        {
            var post = await repository.GetWithComments(id);
            if (post != null)
            {
                return Result.Ok(post);
            }

            return Result.Fail<Post>("Entity not found");
        }
    }
}
