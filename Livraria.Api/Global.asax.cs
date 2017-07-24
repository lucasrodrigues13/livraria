using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Livraria.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            InitializeContainer(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        private static void InitializeContainer(Container container)
        {
            Book.Infra.IoC.BootStrapper.Register(container);
        }
    }
}
