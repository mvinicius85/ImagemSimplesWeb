using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ImagemSimplesWeb
{
    public class Global : HttpApplication
    {
        private static SimpleInjector.Container container;
        public static SimpleInjector.Container Container
        {
            get { return RetornarContainer(); }

        }

        private static SimpleInjector.Container RetornarContainer()
        {
            return container;
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            container = new SimpleInjector.Container();
            ImagemSimplesWeb.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            ImagemSimplesWeb.Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
        }
    }
}