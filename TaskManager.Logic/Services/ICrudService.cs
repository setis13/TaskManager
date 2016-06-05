using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Logic.Dtos;

namespace TaskManager.Logic.Services {
    /// <summary>
    ///     Generic CRUD service contract
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface ICrudService<T> : IService where T : BaseDto {
        /// <summary>
        ///     Save model
        /// </summary>
        /// <param name="model"></param>
        void Save(T model);

        /// <summary>
        ///     Delete model
        /// </summary>
        /// <param name="model">Model</param>
        void Delete(T model);

        /// <summary>
        ///     Delete mnodel by Id
        /// </summary>
        /// <param name="modelId">Model id</param>
        void Delete(Guid modelId);

        /// <summary>
        ///     Get all models list
        /// </summary>
        /// <returns>Models list</returns>
        List<T> GetAll();

        IQueryable<TEntity> GetQuery<TEntity>();

        /// <summary>
        ///     Get model by ID
        /// </summary>
        /// <param name="id">Model ID</param>
        /// <returns>Model</returns>
        T GetById(Guid id);

        /// <summary>
        /// Searches entities with predicate
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns>Models list</returns>
        List<T> SearchFor<TEntity>(Expression<Func<TEntity, bool>> predicate);
    }
}