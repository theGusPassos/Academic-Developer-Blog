using System;

namespace AcaDev.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }
    }
}