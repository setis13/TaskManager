﻿using System;
using System.Collections.Generic;
using TaskManager.Logic.Services;

namespace TaskManager.Logic {
    /// <summary>
    ///     Services host implementation
    /// </summary>
    public class ServicesHost : IServicesHost {
        /// <summary>
        ///     Holds registered services
        /// </summary>
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        /// <summary>
        ///     Register Service with type T
        /// </summary>
        /// <typeparam name="T">Service Type</typeparam>
        /// <param name="service">Service instance</param>
        public void Register<T>(T service) where T : IService {
            if (!_services.ContainsKey(typeof (T)))
                _services.Add(typeof (T), service);
        }

        /// <summary>
        ///     Get Service by it's type
        /// </summary>
        /// <typeparam name="T">Service type</typeparam>
        /// <returns>Service instance</returns>
        public T GetService<T>() where T : IService {
            if (_services.ContainsKey(typeof (T)))
                return (T) _services[typeof (T)];
            return default(T);
        }
    }
}