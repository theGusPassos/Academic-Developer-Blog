using AcaDev.Model.Entities;
using AcaDev.Model.IService;

namespace AcaDev.Controllers
{
    public class TagController : BaseController<Tag, ITagsService>
    {
        public TagController(ITagsService service) : base(service)
        {
        }
    }
}
