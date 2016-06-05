using System;

namespace TaskManager.Logic.Dtos {
    public class CommentDto : BaseDto {
        public string Text { get; set; }
        public byte Status { get; set; }
        public byte Progress { get; set; }
        public double Hours { get; set; }
        public Guid TaskId { get; set; }
    }
}
