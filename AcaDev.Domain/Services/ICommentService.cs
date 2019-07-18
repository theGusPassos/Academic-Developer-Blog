using AcaDev.Domain.Entities;

namespace AcaDev.Domain.Services
{
    public interface ICommentService
    {
        bool IsValidComment(Comment comment);
    }
}
