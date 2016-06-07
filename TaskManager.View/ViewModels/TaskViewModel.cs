using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Common.Enums;
using TaskManager.Common.Extension;
using TaskManager.Logic.Dtos;

namespace TaskManager.View.ViewModels {
    public class TaskViewModel : BaseViewModel, ICloneable {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Hours { get; set; }
        public byte Important { get; set; }

		public TaskStatus Status {
			get { return Comments.Count > 0 ? Comments.OrderBy(c => c.Date).Last().Status : TaskStatus.InProgress; }
		}
		public string StatusDescription {
            get { return Status.GetDescription(); }
        }

        public byte Progress {
            get {
                return Comments.Count > 0 ? Comments.OrderBy(c => c.Date).Last().Progress : (byte)0;
            }
        }

        public double WorkedHours {
            get { return Comments.Sum(c => c.Hours); }
        }

        public IList<CommentViewModel> Comments { get; set; }

        public TaskViewModel() { }

        public TaskViewModel(TaskDto dto)
            : base(dto) {
            Name = dto.Name;
            Description = dto.Description;
            Hours = dto.Hours;
            Comments = dto.Comments.Select(c => new CommentViewModel(c)).ToList();
        }

        public object Clone() {
            return new TaskViewModel() {
                Comments = Comments.Select(c => (CommentViewModel)c.Clone()).ToList(),
                Description = Description,
                CreatedDate = CreatedDate,
                Hours = Hours,
                EntityId = EntityId,
                IsDeleted = IsDeleted,
                LastModifiedDate = LastModifiedDate,
                Name = Name
            };
        }
    }
}
