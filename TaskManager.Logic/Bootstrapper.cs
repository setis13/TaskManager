using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using TaskManager.Data;
using TaskManager.Data.Context;
using TaskManager.Logic.Mappings;
using TaskManager.Logic.Services;

namespace TaskManager.Logic {
    /// <summary>
    /// Represents bootstrapper for unity container
    /// </summary>
    public class Bootstrapper {
        /// <summary>
        /// Initializes unity container
        /// </summary>
        public static void Initialize() {
            var container = new UnityContainer();
            // Services
            container.RegisterType<ITaskService, TaskService>(new ContainerControlledLifetimeManager());
			container.RegisterType<ICommentService, CommentService>(new ContainerControlledLifetimeManager());
			container.RegisterType<IReportService, ReportService>(new ContainerControlledLifetimeManager());
			container.RegisterType<IServicesHost, ServicesHost>(new ContainerControlledLifetimeManager());

			container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
			container.RegisterType<ITaskManagerDbContext, TaskManagerDbContext>(new ContainerControlledLifetimeManager());

			AutoMapper.Mapper.AddProfile<BllMappingProfile>();
			AutoMapper.Mapper.AssertConfigurationIsValid();
			// Set service locator
			ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }
    }
}
