using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tibox.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
