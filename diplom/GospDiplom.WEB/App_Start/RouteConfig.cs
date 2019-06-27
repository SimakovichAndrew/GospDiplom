﻿using System.Web.Mvc;
using System.Web.Routing;

namespace GospDiplom.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: null,
              url: "Page{page}",
              defaults: new { Controller = "Comment"/**/, action = "Chat"/**/ }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { id = UrlParameter.Optional, name = UrlParameter.Optional });

        }
    }
}
