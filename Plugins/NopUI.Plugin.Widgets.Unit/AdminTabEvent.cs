namespace NopUI.Plugin.Widgets.Unit
{
    using Nop.Services.Events;
    using Nop.Web.Framework.Events;
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Text;

    public class AdminTabEvent : IConsumer<AdminTabStripCreated>
    {
        public void HandleEvent(AdminTabStripCreated eventMessage)
        {
            if (eventMessage.TabStripName == "product-edit")
            {
                int num = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["ID"]);
                StringBuilder sb = new StringBuilder();
                string url = "/Plugins/WidgetsUnit/ProductUnit/" + num;
                sb.Append("<script  type=\"text/javascript\">");
                sb.Append("$(document).ready(function () {");
                sb.Append("var kTabs = $('#product-edit').data('kendoTabStrip');");
                sb.Append(" kTabs.append({ text: \"单位管理\", contentUrl: \"" + url + "\" });");
                sb.Append("});");
                sb.Append("</script>");
                eventMessage.BlocksToRender.Add(MvcHtmlString.Create(sb.ToString()));
            }
        }
    }
}

