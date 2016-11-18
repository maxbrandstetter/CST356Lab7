using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Lab_2.Data;
using Lab_2.Services;


namespace Lab_2.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register types
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserService, UserService>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}