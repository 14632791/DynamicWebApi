using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Southernfund.UpdateSystem.IService;
using Southernfund.UpdateSystem.Service;

namespace Southernfund.UpdateSystem.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IProjects, ProjectsService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUpdate, UpdateService>(new ContainerControlledLifetimeManager());
            
            //container.RegisterType<IRoleService, RoleService>(new ContainerControlledLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}