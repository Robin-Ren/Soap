using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sopon
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Outcome", action = "Outcome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 "UpdateOutcomeView", // Route name
                 "Outcome/", // URL 
                 new { controller = "Outcome", action = "UpdateOutcomeView" } // Parameter defaults
                 );
        }
    }
}