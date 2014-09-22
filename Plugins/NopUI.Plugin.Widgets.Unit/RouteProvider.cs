using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;
using NopUI.Plugin.Widgets.Unit.Infrastructure;

namespace NopUI.Plugin.Widgets.Unit
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Widgets.Unit.Config",
                "Plugins/WidgetsUnit/Config",
                new { controller = "WidgetsUnit", action = "Config" },
                new[] { "NopUI.Plugin.Widgets.WidgetsUnit.Controllers" }
           );
            routes.MapRoute("Plugin.Widgets.Unit.ProductUnit",
               "Plugins/WidgetsUnit/ProductUnit/{productId}",
               new { controller = "WidgetsUnit", action = "ProductUnit" },
               new[] { "NopUI.Plugin.Widgets.WidgetsUnit.Controllers" }
          );

            routes.MapRoute("Plugin.Widgets.Unit.ProductUnitSave",
              "Plugins/WidgetsUnit/ProductUnitSave",
              new { controller = "WidgetsUnit", action = "ProductUnitSave" },
              new[] { "NopUI.Plugin.Widgets.WidgetsUnit.Controllers" }
         );
            ViewEngines.Engines.Add(new CustomViewEngine());
        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
