using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;
using NopUI.Core.Infrastructure;

namespace NopUI.Core
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
           // ViewEngines.Engines.Insert(0, new CustomViewEngine());
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
