using System.Threading.Tasks;
using AcaDev.Model.Dtos;
using AcaDev.Model.Entities;
using AcaDev.Model.IRepository;
using AcaDev.Model.IService;
using AcaDev.Shared;

namespace AcaDev.Model.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository repository;

        public CommentsService(ICommentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Comment>> Create(CommentDto dto)
        {
            var comment = Comment.Create(dto);
            await repository.Add(comment);

            return Result.Ok(comment);
        }
    }
}
