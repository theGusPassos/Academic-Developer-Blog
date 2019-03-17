using AcaDev.Model.Entities;
using AcaDev.Model.IRepository;
using AcaDev.Model.IService;

namespace AcaDev.Model.Services
{
    public class TagsService : BaseService<Tag, ITagsRepository>, ITagsService
    {
        public TagsService(ITagsRepository repository) : base(repository)
        {
        }
    }
}
