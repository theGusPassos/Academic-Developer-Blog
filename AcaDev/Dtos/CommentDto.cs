using AcaDev.Domain.Entities;
using System;

namespace AcaDev.Dtos
{
    public class CommentDto
    {
        public string Username { get; set; }
        public string Content { get; set; }

        public Comment ToComment(int postId)
        {
            return new Comment
            {
                Author = this.Username,
                Content = this.Content,
                PostId = postId,
                Date = DateTime.UtcNow
            };
        }
    }
}
