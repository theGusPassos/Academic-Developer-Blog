using AcaDev.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AcaDev.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public List<string> Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
