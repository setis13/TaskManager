using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Logic.Dtos;

namespace TaskManager.Logic.Services {
    public class EntityCrudService<TService ,TDto, TEntity> : ICrudService<TDto> where TDto : BaseDto where TEntity : BaseEntity where TService : IService {
        protected readonly IUnitOfWork UnitOfWork;

        public EntityCrudService(IServicesHost servicesHost, IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
            servicesHost.Register((TService)(this as IService));
        }

        /// <summary>
        ///     Save model to database
        /// </summary>
        /// <param name="model">The model</param>
        public void Save(TDto model) {
            var store = this.UnitOfWork.GetEntityRepository<TEntity>().GetById(model.EntityId);

            if (store == null) {
                store = AutoMapper.Mapper.Map<TEntity>(model);
                this.UnitOfWork.GetEntityRepository<TEntity>().Insert(store);
                store.EntityId = Guid.NewGuid();
                store.CreatedDate = store.LastModifiedDate = DateTime.Now;
            } else {
                AutoMapper.Mapper.Map(model, store);
                this.UnitOfWork.GetEntityRepository<TEntity>().Update(store);
                store.LastModifiedDate = DateTime.Now;
            }

            this.UnitOfWork.SaveChanges();
        }

        /// <summary>
        ///     Delete model from database
        /// </summary>
        /// <param name="model">The model</param>
        public void Delete(TDto model) {
            this.UnitOfWork.GetEntityRepository<TEntity>().Delete(model.EntityId);
            this.UnitOfWork.SaveChanges();
        }

        /// <summary>
        ///     Delete model from database by model Id
        /// </summary>
        /// <param name="modelId">The model Id</param>
        public void Delete(Guid modelId) {
            this.UnitOfWork.GetEntityRepository<TEntity>().Delete(modelId);
            this.UnitOfWork.SaveChanges();
        }

        /// <summary>
        ///     Delete existing entity by its ids
        /// </summary>
        /// <param name="ids">List of Entity Ids</param>
        public void Delete(List<Guid> ids) {
            this.UnitOfWork.GetEntityRepository<TEntity>().Delete(ids);
            IQueryable<TEntity> models = this.UnitOfWork.GetEntityRepository<TEntity>().SearchFor(m => ids.Contains(m.EntityId));

            foreach (var model in models.ToList()) {
                this.UnitOfWork.GetEntityRepository<TEntity>().Delete(model);
            }
            this.UnitOfWork.SaveChanges();
        }

        /// <summary>
        ///     The model get by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TDto" />.</returns>
        public TDto GetById(Guid id) {
            var store = this.UnitOfWork.GetEntityRepository<TEntity>().GetById(id);
            return AutoMapper.Mapper.Map<TDto>(store);
        }

        /// <summary>
        ///     Get all models list
        /// </summary>
        /// <returns>Sessions</returns>
        public List<TDto> GetAll() {
            var store = this.UnitOfWork.GetEntityRepository<TEntity>().GetAll();
            return AutoMapper.Mapper.Map<List<TDto>>(store);
        }

        /// <summary>
        ///     Get all
        /// </summary>
        /// <returns>Sessions</returns>
        public IQueryable<TEntity> GetQuery<TEntity>() {
            return this.UnitOfWork.GetEntityRepository<TEntity>().GetAll();
        }

        /// <summary>
        ///     Searches entities with predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>List of entities</returns>
        public List<TDto> SearchFor<TEntity>(Expression<Func<TEntity, bool>> predicate) {
            var store = this.UnitOfWork.GetEntityRepository<TEntity>().SearchFor(predicate).ToList();
            return AutoMapper.Mapper.Map<List<TDto>>(store);
        }
    }
}