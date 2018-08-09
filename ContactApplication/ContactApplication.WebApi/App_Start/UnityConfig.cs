using System.Web.Http;
using ContactApplication.Database.Repository;
using Unity;
using Unity.WebApi;

namespace ContactApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();
            
            container.RegisterType<IContactRepository, ContactRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}