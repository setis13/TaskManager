using System;
using System.Collections.Generic;

namespace TaskManager.Logic.Dtos {
    public class TaskDto : BaseDto {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Hours { get; set; }
        public byte Important { get; set; }
		[AutoMapper.IgnoreMap]
        public IList<CommentDto> Comments { get; set; }
    }
}
