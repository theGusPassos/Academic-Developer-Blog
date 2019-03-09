using AcaDev.Model.Entities;
using AcaDev.Shared;
using System.Threading.Tasks;

namespace AcaDev.Model.IService
{
    public interface IPostsService : IService<Post>
    {
        Task<Result<Post>> GetWithComments(int id);
    }
}
