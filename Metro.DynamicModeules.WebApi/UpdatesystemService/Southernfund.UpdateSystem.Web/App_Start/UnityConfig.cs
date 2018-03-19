using Metro.DynamicModeules.Interface.Service;
using Metro.DynamicModeules.Interface.Service.Update;
using Metro.DynamicModeules.Service;
using Metro.DynamicModeules.Service.Update;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc5;

namespace UpdateSystem.Web
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
            container.RegisterType<IMyUser, MyUserService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUpProject, UpProjectService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUpdate, UpdateService>(new ContainerControlledLifetimeManager());
            
            //container.RegisterType<IRoleService, RoleService>(new ContainerControlledLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}