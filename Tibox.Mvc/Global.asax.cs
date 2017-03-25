using LightInject;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tibox.Mvc.App_Start;

namespace Tibox.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureInjection();
        }

        private void ConfigureInjection()
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("Tibox.Repository*.dll");
            container.RegisterAssembly("Tibox.UnitOfWork*.dll");
            container.RegisterControllers();
            container.EnableMvc();
        }
    }
}
