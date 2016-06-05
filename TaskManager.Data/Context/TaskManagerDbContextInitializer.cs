using System.Data.Entity;

namespace TaskManager.Data.Context {
    /// <summary>
    ///     Application db context initializer (migrations)
    /// </summary>
    public class TaskManagerDbContextInitializer :
        MigrateDatabaseToLatestVersion<TaskManagerDbContext, TaskManagerDbContextConfiguration> {
    }
}