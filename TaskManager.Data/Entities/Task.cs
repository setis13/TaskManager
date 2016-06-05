using System;
using System.Collections.Generic;

namespace TaskManager.Data.Entities {
    public class Task : BaseEntity {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Important { get; set; }
        public double Hours { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
