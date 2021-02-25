using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Task5.BLL.Extentions;
using Task5.WebClient.Extensions;
using Task5.WebClient.Models;

namespace Task5.WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BLL.Extentions.MapperHelper.MapperConfig();

            NinjectModule bllRegistrations = new NinjectRegistrations();
            var bllKernel = new StandardKernel(bllRegistrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(bllKernel));

            NinjectModule webRegistrations = new WebNinjectRegistrations();
            var webKernel = new StandardKernel(webRegistrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(webKernel));

        }
    }
}
