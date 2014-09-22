using Nop.Web.Framework.Themes;

namespace NopUI.Core.Infrastructure
{
    public class CustomViewEngine : ThemeableRazorViewEngine
    {
        public CustomViewEngine()
        {
            ViewLocationFormats = new[] { "~/Plugins/NopUI.Core/Views/{1}/{0}.cshtml", "~/Plugins/NopUI.Core/Views/{0}.cshtml" };
            PartialViewLocationFormats = new[] { "~/Plugins/NopUI.Core/Views/{1}/{0}.cshtml", "~/Plugins/NopUI.Core/Views/{0}.cshtml" };
        }
    }
}
