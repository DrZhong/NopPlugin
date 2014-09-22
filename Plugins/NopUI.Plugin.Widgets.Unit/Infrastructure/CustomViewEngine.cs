using Nop.Web.Framework.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopUI.Plugin.Widgets.Unit.Infrastructure
{
    public class CustomViewEngine : ThemeableRazorViewEngine
    {
        public CustomViewEngine()
        {
            ViewLocationFormats = new[] { "~/Plugins/NopUI.Widgets.Unit/Views/{1}/{0}.cshtml" };
            PartialViewLocationFormats = new[] { "~/Plugins/NopUI.Widgets.Unit/Views/{1}/{0}.cshtml" };
        }
    }
}
