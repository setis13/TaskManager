﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskManager.Data.Context;
using TaskManager.Data.Entities;

namespace TaskManager.Data.Repositories {
    /// <summary>
    ///     Base entity repository implementation
    /// </summary>
    /// <typeparam name="T">BaseEntity</typeparam>
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity {
        
        /// <summary>
        ///     Holds db context instance
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        ///     Holds generic db set
        /// </summary>
        protected readonly DbSet<T> DbSet;

        /// <summary>
        ///     Creates entity repository
        /// </summary>
        /// <param name="dbContext">Db Context</param>
        public EntityRepository(ITaskManagerDbContext dbContext) {
            Context = (DbContext) dbContext;
            DbSet = Context.Set<T>();
        }
        
        /// <summary>
        ///     Search entities using predicate expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Entities list</returns>
        public virtual IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate) {
            return GetAll().Where(predicate);
        }

        /// <summary>
        ///     Gets all entities list
        /// </summary>
        /// <returns>Entities list</returns>
        public virtual IQueryable<T> GetAll() {
            return DbSet.Where(e => e.IsDeleted == false);
        }

        /// <summary>
        ///     Get entity by PK Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity instance</returns>
        public virtual T GetById(Guid id) {
            return DbSet.Find(id);
        }

        /// <summary>
        ///     Insert a new entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Insert(T entity) {
            var entityEntry = Context.Entry(entity);
            if (entityEntry.State != EntityState.Detached) {
                entityEntry.State = EntityState.Added;
            } else {
                DbSet.Add(entity);
            }
        }

        /// <summary>
        ///     Update existing entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Update(T entity) {
            var entityEntry = Context.Entry(entity);
            if (entityEntry.State == EntityState.Detached) {
                DbSet.Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
        }

        /// <summary>
        ///     Delete existing entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Delete(T entity) {
            DbSet.Remove(entity);
        }

        /// <summary>
        ///     Delete existing entity bby its id
        /// </summary>
        /// <param name="id">Entity Id</param>
        public virtual void Delete(Guid id) {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        /// <summary>
        ///     Delete existing entity by its ids
        /// </summary>
        /// <param name="ids">List of Entity Ids</param>
        public virtual void Delete(IReadOnlyCollection<Guid> ids) {
            foreach (var id in ids) {
                Delete(id);
            }
        }
    }
}


























