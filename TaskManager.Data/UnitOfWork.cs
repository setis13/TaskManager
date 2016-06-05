using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using TaskManager.Data.Context;
using TaskManager.Data.Repositories;

namespace TaskManager.Data {
    /// <summary>
    ///     UOW interface implementation
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable {

        /// <summary>
        ///     Holds registered entity repositories
        /// </summary>
        private readonly Dictionary<Type, IEntityRepository> _entityRepositories;

        /// <summary>
        ///     Thread safe locker
        /// </summary>
        private readonly object _lockObject = new object();

        /// <summary>
        ///     Gets application db context instance
        /// </summary>
        public ITaskManagerDbContext Context { get; private set; }

        /// <summary>
        ///     Create UOW instance
        /// </summary>
        /// <param name="context">Application db context</param>
        public UnitOfWork(ITaskManagerDbContext context) {
            _entityRepositories = new Dictionary<Type, IEntityRepository>();
            Context = context;
        }

        /// <summary>
        ///     Get repository by entity type
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Repository instance</returns>
        public IEntityRepository<T> GetEntityRepository<T>() {
            // check if repository exist in cache
            if (_entityRepositories.ContainsKey(typeof(T)))
                return _entityRepositories[typeof(T)] as IEntityRepository<T>;
            // if not then create a new instance and add to cache
            var repositoryType = typeof(EntityRepository<>).MakeGenericType(typeof(T));
            var repository = (IEntityRepository<T>)Activator.CreateInstance(repositoryType, this.Context);
            _entityRepositories.Add(typeof(T), repository);

            return repository;
        }

        /// <summary>
        ///     The roll back.
        /// </summary>
        public void RollBack() {
            var changedEntries =
                this.Context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified)) {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added)) {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted)) {
                entry.State = EntityState.Unchanged;
            }
        }

        /// <summary>
        ///     The commit.
        /// </summary>
        public void SaveChanges() {
            try {
                Monitor.Enter(_lockObject);
                this.Context.SaveChanges();
            } catch (DbEntityValidationException ex) {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors) {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors) {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
                    // Add the original exception as the innerException
            } finally {
                Monitor.Exit(_lockObject);
            }
        }

        public void Dispose() {
            Context.Dispose();
        }
    }
}