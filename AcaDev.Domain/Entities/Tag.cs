﻿using System.Collections.Generic;

namespace AcaDev.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}