using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Logic.Dtos;
using Task = TaskManager.Data.Entities.Task;

namespace TaskManager.Logic.Services {

	public class ReportService : HostService<IReportService>, IReportService {

		#region [ .ctor ]

		/// <summary>
		///     Initializes a new instance of the <see cref="ReportService"/> class.
		/// </summary>
		public ReportService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
			: base(servicesHost, unitOfWork) {
		}

		#endregion [ .ctor ]

		public IReadOnlyCollection<TaskDto> DayReport(DateTime dateTime1, DateTime dateTime2) {
			var comments = base.UnitOfWork.GetEntityRepository<Comment>().GetAll();
			var tasks = base.UnitOfWork.GetEntityRepository<Task>().GetAll();

			DateTime start = dateTime1.Date;
			DateTime end = dateTime2.Date.AddDays(1);

			var query = from comment in comments
						where comment.Date >= start && comment.Date < end && comment.IsDeleted == false
						select comment;

			var result = new List<TaskDto>();

			foreach (Comment comment in query.Include("Task")) {
				if (result.Any(t => t.EntityId == comment.TaskId) == false) {
					result.Add(new TaskDto() {
						EntityId = comment.Task.EntityId,
						CreatedDate = comment.Task.CreatedDate,
						Description = comment.Task.Description,
						Hours = comment.Task.Hours,
						IsDeleted = comment.Task.IsDeleted,
						LastModifiedDate = comment.Task.LastModifiedDate,
						Name = comment.Task.Name,
						Important = comment.Task.Important,
						Comments = new List<CommentDto>()
					});
				}
				result.Single(t => t.EntityId == comment.TaskId).Comments.Add(new CommentDto() {
					EntityId = comment.EntityId,
                    CreatedDate = comment.CreatedDate,
                    Date = comment.Date,
                    IsDeleted = comment.IsDeleted,
					Progress = comment.Progress,
					Hours = comment.Hours,
					Status = comment.Status,
					LastModifiedDate = comment.LastModifiedDate,
					TaskId = comment.TaskId,
					Text = comment.Text
				});
			}
			return result;
		}
	}
}
