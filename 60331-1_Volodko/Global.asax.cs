using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;
using _60331_1_Volodko.DAL;
using _60331_1_Volodko.Models;
using _60331_1_Volodko.Binders;

namespace _60331_1_Volodko
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IRepository<Car>>().To<EFCarRepository>();
            return kernel;
        }
    }
}
