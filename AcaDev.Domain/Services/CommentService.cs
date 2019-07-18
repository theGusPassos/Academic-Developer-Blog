using AcaDev.Domain.Entities;

namespace AcaDev.Domain.Services
{
    public class CommentService : ICommentService
    {
        public bool IsValidComment(Comment comment)
        {
            return !string.IsNullOrWhiteSpace(comment.Content) &&
                    !string.IsNullOrWhiteSpace(comment.Author);
        }
    }
}
