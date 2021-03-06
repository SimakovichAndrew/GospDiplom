﻿using GospDiplom.BLL.Infrastructure;
using GospDiplom.WEB.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GospDiplom.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule orderModule = new OrderModule();
            NinjectModule serviceModule = new ServiceModule("GospContext");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            // ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
