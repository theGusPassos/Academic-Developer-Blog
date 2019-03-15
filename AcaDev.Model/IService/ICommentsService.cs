using AcaDev.Model.Dtos;
using AcaDev.Model.Entities;
using AcaDev.Shared;
using System.Threading.Tasks;

namespace AcaDev.Model.IService
{
    public interface ICommentsService
    {
        Task<Result<Comment>> Create(CommentDto dto);
    }
}
