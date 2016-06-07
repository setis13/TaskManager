using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Data.Entities {
    public class Comment : BaseEntity {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public byte Status { get; set; }
        public byte Progress { get; set; }
        public double Hours { get; set; }
        public Guid TaskId { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
    }
}
