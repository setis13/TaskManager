using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaskManager.Common.Enums;
using TaskManager.Common.Extension;

namespace TaskManager.View.ViewModels {
    public class WrapCommentViewModel {

		public TaskViewModel TaskViewModel { get; set; }
		public CommentViewModel CommentViewModel { get; set; }
		public List<TaskStatus> Statuses { get; set; }

        public WrapCommentViewModel(TaskViewModel taskViewModel) {
	        TaskViewModel = taskViewModel;
	        CommentViewModel = new CommentViewModel() {TaskId = taskViewModel.EntityId, Status = TaskStatus.InProgress, Date = DateTime.Now};
			Statuses = typeof(TaskStatus).GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => (((TaskStatus)fi.GetValue(null)))).ToList();
		}

		public WrapCommentViewModel(TaskViewModel taskViewModel, CommentViewModel dataContext) : this(taskViewModel) {
			this.CommentViewModel = dataContext;
		}
	}
}
