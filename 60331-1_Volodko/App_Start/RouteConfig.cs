using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _60331_1_Volodko
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //name: "",
            //url: "Catalog",
            //defaults: new
            //{
            //    controller = "Car",
            //    action = "List",
            //    page = 1,
            //    group = (string)null
            //});
            //routes.MapRoute(
            //name: "",
            //url: "Catalog/page{page}",
            //defaults: new
            //{
            //    controller = "Car",
            //    action = "List",
            //    group = (string)null
            //},
            //constraints: new { page = @"\d+" });
            //routes.MapRoute(
            //name: "",
            //url: "Catalog/{group}",
            //defaults: new
            //{
            //    controller = "Car",
            //    action = "List",
            //    page = 1
            //});


            routes.MapRoute(
                name: "",
                url: "Catalog",
                defaults: new
                {
                    controller = "Sweet",
                    action = "List",
                    page = 1,
                    group = (string)null
                });
            routes.MapRoute(
                name: "",
                url: "Catalog/page{page}",
                defaults: new
                {
                    controller = "Sweet",
                    action = "List",
                    group = (string)null
                },
                constraints: new { page = @"\d+" });
            routes.MapRoute(
                name: "",
                url: "Catalog/{group}",
                defaults: new
                {
                    controller = "Sweet",
                    action = "List",
                    page = 1
                });



            routes.MapRoute(
            name: "",
            url: "Catalog/{group}/page{page}",
            defaults: new { controller = "Car", action = "List" },
            constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
