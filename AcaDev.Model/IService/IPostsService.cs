using AcaDev.Model.Entities;
using AcaDev.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcaDev.Model.IService
{
    public interface IPostsService : IService<Post>
    {
        Task<Result<Post>> GetWithComments(int id);
        Task<Result<List<Post>>> GetByTag(int tagId);
    }
}
