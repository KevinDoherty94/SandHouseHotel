using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolTourProject
{
    public class RouteConfig
    {


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
              name: "Default4",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "BookingActivities", action = "Create", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Default3",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Bookings", action = "Create", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "Default2",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Activities", action = "SiteSeeing", id = UrlParameter.Optional }
           );
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
        }

    }
}
