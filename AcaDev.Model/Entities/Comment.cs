using AcaDev.Model.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcaDev.Model.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Author { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Content { get; set; }

        public static Comment Create(CommentDto dto)
            => new Comment
            {
                Author = dto.Author,
                Content = dto.Content
            };
    }
}