using System.Collections.Generic;
using TaskManager.Logic.Dtos;

namespace TaskManager.Logic.Services {
    public interface ITaskService : ICrudService<TaskDto> {
        IReadOnlyCollection<TaskDto> GetTasks(bool inProgressFlag, bool doneFlag);
        void SaveTask(TaskDto task);
    }
}
