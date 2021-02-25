using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task5.BLL.Services.Abstruct;
using Task5.BLL.Services.Contract;

namespace Task5.WebClient.Extensions
{
    public class WebNinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientService>().To<IClientService>();
            Bind<IProductService>().To<IProductService>();
            Bind<IOrderService>().To<IOrderService>();
        }
    }
}