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

            MapperHelper.MapperConfig();
            Task5.BLL.Extentions.MapperHelper.MapperConfig();

            NinjectModule bllRegistrations = new BLL.Extentions.NinjectRegistrations();
            NinjectModule webRegistrations = new WebNinjectRegistrations();
            var kernel = new StandardKernel(bllRegistrations, webRegistrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            kernel.Unbind<ModelValidatorProvider>();
        }
    }
}
