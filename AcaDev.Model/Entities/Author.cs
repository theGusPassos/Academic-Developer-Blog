using System.ComponentModel.DataAnnotations.Schema;

namespace AcaDev.Model.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
    }
}