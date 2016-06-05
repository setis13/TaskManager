using TaskManager.Data.Entities;

namespace TaskManager.Data.Mappings {
    class TaskMap : BaseEntityMap<Task> {
        public TaskMap() {
            this.ToTable("Task");
        }
    }
}
