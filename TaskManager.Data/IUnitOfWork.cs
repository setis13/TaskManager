using TaskManager.Data.Context;
using TaskManager.Data.Repositories;

namespace TaskManager.Data {
    /// <summary>
    ///     UOW contract
    /// </summary>
    public interface IUnitOfWork {

        /// <summary>
        ///     Gets application context instance
        /// </summary>
        ITaskManagerDbContext Context { get; }


        /// <summary>
        ///     Get repository by entity type
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Repository instance</returns>
        IEntityRepository<T> GetEntityRepository<T>();

        /// <summary>
        ///     Rollback uncommited changes
        /// </summary>
        void RollBack();

        /// <summary>
        ///     Commit changes
        /// </summary>
        void SaveChanges();
    }
}