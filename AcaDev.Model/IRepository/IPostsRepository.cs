using AcaDev.Model.Entities;
using System.Threading.Tasks;

namespace AcaDev.Repository.Repositories.Interfaces
{
    public interface IPostsRepository : IRepository<Post>
    {
        Task<Post> GetWithComments(int id);
    }
}