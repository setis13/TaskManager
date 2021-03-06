﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TaskManager.Data.Repositories {
    /// <summary>
    ///     Base repository interface
    /// </summary>
    public interface IEntityRepository {
    }

    /// <summary>
    ///     Base entity repository interface
    /// </summary>
    /// <typeparam name="T">BaseEntity</typeparam>
    public interface IEntityRepository<T> : IEntityRepository {

        /// <summary>
        ///     Search entities using predicate expression
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Entities list</returns>
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///     Gets all entities list
        /// </summary>
        /// <returns>Entities list</returns>
        IQueryable<T> GetAll();

        /// <summary>
        ///     Get entity by PK Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity instance</returns>
        T GetById(Guid id);

        /// <summary>
        ///     Insert a new entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Insert(T entity);

        /// <summary>
        ///     Update existing entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Update(T entity);

        /// <summary>
        ///     Delete existing entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Delete(T entity);

        /// <summary>
        ///     Delete existing entity bby its id
        /// </summary>
        /// <param name="id">Entity Id</param>
         void Delete(Guid id);

        /// <summary>
        ///     Delete existing entity by its ids
        /// </summary>
        /// <param name="ids">List of Entity Ids</param>
        void Delete(IReadOnlyCollection<Guid> ids);
    }
}