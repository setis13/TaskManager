using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Logic.Dtos;
using Task = TaskManager.Data.Entities.Task;

namespace TaskManager.Logic.Services {

    public class TaskService : EntityCrudService<ITaskService, TaskDto, Task>, ITaskService {

        #region [ .ctor ]

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public TaskService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }

        #endregion [ .ctor ]

        public IReadOnlyCollection<TaskDto> GetTasks(bool inProgressFlag, bool doneFlag) {
            IQueryable<Task> tasks = base.UnitOfWork.GetEntityRepository<Task>().GetAll();
            ILookup<Guid, Comment> comments = base.UnitOfWork.GetEntityRepository<Comment>().GetAll().OrderBy(c => c.CreatedDate).ToLookup(c => c.TaskId);

            var result = new List<TaskDto>();

            foreach (var task in tasks) {
                if (comments.Contains(task.EntityId) == false || 
(inProgressFlag == true && 
(comments[task.EntityId].Last().Status & (
	(byte)Common.Enums.TaskStatus.InProgress |
	(byte)Common.Enums.TaskStatus.NeedFeedback | 
	(byte)Common.Enums.TaskStatus.None)) != 0) ||
(doneFlag == true &&
(comments[task.EntityId].Last().Status & (
	(byte)Common.Enums.TaskStatus.Done |
	(byte)Common.Enums.TaskStatus.Rejected)) != 0)) {
                    result.Add(new TaskDto() {
                        EntityId = task.EntityId,
                        CreatedDate = task.CreatedDate,
                        Description = task.Description,
                        Hours = task.Hours,
                        IsDeleted = task.IsDeleted,
                        LastModifiedDate = task.LastModifiedDate,
                        Name = task.Name,
                        Comments = comments[task.EntityId].Select(c => new CommentDto() {
                            EntityId = c.EntityId,
                            CreatedDate = c.CreatedDate,
                            IsDeleted = c.IsDeleted,
                            Progress = c.Progress,
                            Hours = c.Hours,
                            Status = c.Status,
                            LastModifiedDate = c.LastModifiedDate,
                            TaskId = c.TaskId,
                            Text = c.Text
                        }).ToList()
                    });
                }
            }

            return result.OrderByDescending(t =>t.CreatedDate).ToList();
        }

        public void SaveTask(TaskDto task) {
            this.Save(task);
        }
    }
}
