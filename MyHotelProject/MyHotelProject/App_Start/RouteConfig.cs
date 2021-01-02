using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyHotelProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
            name: "Booking Success",
            url: "hoan-thanh-don-dat-phong",
            defaults: new { controller = "Booking", action = "Success", id = UrlParameter.Optional },
            namespaces: new[] { "Shopie.Controllers" }
);
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Confirm",
             url: "thanh-toan",
             defaults: new { controller = "Booking", action = "Confirm", id = UrlParameter.Optional },
             namespaces: new[] { "MyHotelProject.Controllers" }
         );

            routes.MapRoute(
             name: "Add Checkin",
             url: "them-don-dat-phong",
             defaults: new { controller = "Booking", action = "Reservation", id = UrlParameter.Optional },
             namespaces: new[] { "MyHotelProject.Controllers" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MyHotelProject.Controllers" }
            );
        }
    }
}
