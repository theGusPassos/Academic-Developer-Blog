using AcaDev.Model.Entities;
using AcaDev.Model.IService;

namespace AcaDev.Controllers
{
    public class PostsController : BaseController<Post, IPostsService>
    {
        public PostsController(IPostsService service) : base(service)
        {
        }
    }
}
