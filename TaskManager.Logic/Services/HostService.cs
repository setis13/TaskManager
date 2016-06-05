﻿using TaskManager.Data;

namespace TaskManager.Logic.Services {
    /// <summary>
    ///     Base services abstract class
    /// </summary>
    public abstract class HostService<T> : IService where T : IService {
        /// <summary>
        ///     The unit of work.
        /// </summary>
        protected readonly IUnitOfWork UnitOfWork;

        /// <summary>
        ///     Creates
        /// </summary>
        /// <param name="servicesHost"></param>
        /// <param name="unitOfWork"></param>
        protected HostService(IServicesHost servicesHost, IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
            servicesHost.Register((T) (this as IService));
        }
    }
}