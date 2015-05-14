using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QuickBootstrap.Helpers;

namespace QuickBootstrap
{
    public class RouteConfig
    {
        static readonly string _domainRegular = null;

        static RouteConfig()
        {
            _domainRegular = ConfigurationManager.AppSettings["DomainRegular"];
            if (string.IsNullOrWhiteSpace(_domainRegular)) throw new NotImplementedException();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("DomainRoute", new DomainRoute(
                 _domainRegular,       //Domain with parameters
                 "{controller}/{action}/{id}",      //URL with parameters
                 new { company = string.Empty, controller = "Home", action = "Index", id = UrlParameter.Optional }  //Parameter defaults
                ));
            routes.Add("DomainRoute_Page", new DomainRoute(
                 _domainRegular,       //Domain with parameters
                 "{controller}/{action}/{id}_{pageIndex}_{pageSize}",      //URL with parameters
                 new { company = string.Empty, controller = "Home", action = "Index", id = UrlParameter.Optional }  //Parameter defaults
                ));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
