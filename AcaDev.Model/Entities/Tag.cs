﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AcaDev.Model.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }
    }
}