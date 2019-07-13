using System;
using System.Collections.Generic;

namespace AcaDev.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public List<PostTag> PostTags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
