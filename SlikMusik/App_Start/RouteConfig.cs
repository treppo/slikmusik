using System.Web.Mvc;
using System.Web.Routing;

namespace SlikMusik
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Merchandize",
                url: "Store/{storeId}/Merchandize/{action}/{id}",
                defaults: new {controller = "Merchandize", action = "Create", storeId = "", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Store", action = "List", id = UrlParameter.Optional}
                );
        }
    }
}