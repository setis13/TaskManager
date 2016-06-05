using System;
using TaskManager.Common.Enums;
using TaskManager.Common.Extension;
using TaskManager.Logic.Dtos;

namespace TaskManager.View.ViewModels {
    public class CommentViewModel : BaseViewModel, ICloneable {
	    private TaskStatus _status;
	    private byte _progress;
	    public string Text { get; set; }

	    public TaskStatus Status {
		    get { return _status; }
		    set {
				_status = value;
			    if (value == TaskStatus.Done) {
				    Progress = 100;
			    }
		    }
	    }

	    public string StatusDescription {
		    get { return Status.GetDescription(); }
	    }

	    public byte Progress {
		    get { return _progress; }
		    set {
			    _progress = value;
				OnPropertyChanged();
		    }
	    }

	    public double Hours { get; set; }
        public Guid TaskId { get; set; }

        public CommentViewModel() {
        }

        public CommentViewModel(CommentDto dto) : base(dto) {
            Text = dto.Text;
            Status = (TaskStatus) dto.Status;
            Progress = dto.Progress;
            Hours = dto.Hours;
            TaskId = dto.TaskId;
        }

        public object Clone() {
            return new CommentViewModel() {
                CreatedDate = CreatedDate,
                Hours = Hours,
                EntityId = EntityId,
                IsDeleted = IsDeleted,
                LastModifiedDate = LastModifiedDate,
                TaskId = TaskId,
                Text = Text,
                Progress = Progress,
                Status = Status
            };
        }
    }
}
