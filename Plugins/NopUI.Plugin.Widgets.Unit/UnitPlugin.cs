using System.Collections.Generic;
using System.IO;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using NopUI.Plugin.Widgets.Unit.Data;
using Nop.Web.Framework.Web;
using Nop.Web.Framework.Menu;
using NopUI.Core;

namespace NopUI.Plugin.Widgets.Unit
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class UnitPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        #region ��ʼ��
        private readonly IWebHelper _webHelper;
        private readonly UnitEntityContext _objectContext;
        public UnitPlugin(
            UnitEntityContext objectContext,
            IWebHelper webHelper)
        {
            _objectContext = objectContext;
            this._webHelper = webHelper;
        } 
        #endregion

        

        #region ��ȡ����·��
        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsUnit";
            routeValues = new RouteValueDictionary() { { "Namespaces", "NopUI.Plugin.Widgets.Unit.Controllers" }, { "area", null } };
        } 
        #endregion

        #region ��ȡչʾ·��
        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string>() { "account_navigation_after" };
        }

        /// <summary>
        /// Gets a route for displaying widget
        /// </summary>
        /// <param name="widgetZone">Widget zone where it's displayed</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "WidgetsUnit";
            routeValues = new RouteValueDictionary()
            {
                {"Namespaces", "NopUI.Plugin.Widgets.Unit.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }
        
        #endregion


        #region ��װ
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //var descriptor = _pluginFinder.GetPluginDescriptorBySystemName<IPlugin>("NopUI.Core");
            if (!PublicInterface.IsInstall()){
                //��ʾ���Ĳ��û�а�װ��������װ
                throw new NopException("���Ĳ��û�а�װ��������װ");
            }
            //this.AddOrUpdatePluginLocaleResource("Account.UnitReturnRequests", "�ҵĶ�����Ʒ");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.Name", "��Ʒ����");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.ShortDescription", "��Ʒ����");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.FullDescription", "��Ʒ����");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.MetaKeywords", "Meta�ؼ���");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.MetaDescription", "Meta����");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.MetaTitle", "Meta����");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.Price", "�۸�");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.Published", "�Ƿ񷢲�");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.Deleted", "�Ƿ�ɾ��");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.CreatedOnUtc", "����ʱ��");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.UpdatedOnUtc", "����ʱ��");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.Unit.Fields.PictureId", "��ƷͼƬ");
            //this.AddOrUpdatePluginLocaleResource("Unit.list", "�ҵĶ�����Ʒ�б�");
            //database objects  Unit.list
            _objectContext.Install();

            base.Install();
        } 
        #endregion

        #region ж��
        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {

            ////locales
            //this.DeletePluginLocaleResource("Account.UnitReturnRequests");

            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.Name");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.ShortDescription");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.FullDescription");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.MetaKeywords");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.MetaDescription");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.MetaTitle");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.Price");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.Published");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.Deleted");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.CreatedOnUtc");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.UpdatedOnUtc");
            //this.DeletePluginLocaleResource("Plugins.Widgets.Unit.Fields.PictureId");
            //this.DeletePluginLocaleResource("Unit.list");
            // database objects
            _objectContext.Uninstall();
            base.Uninstall();
        } 
        #endregion

        #region ��̨�˵�
        public bool Authenticate()
        {
            return true;
        }

        public SiteMapNode BuildMenuItem()
        {
            var menuItemBuilder = new SiteMapNode()
            {
                Title = "��λ",   // Title for your Custom Menu Item
                Visible = true
            };

            var SubMenuItem = new SiteMapNode()   // add child Custom menu
            {
                Title = "��λ����", //   Title for your Sub Menu item
                ControllerName = "WidgetsUnit", // Your controller Name
                ActionName = "Manage", // Action Name
                Visible = true,
                RouteValues = new RouteValueDictionary() {
                    {"Namespaces", "NopUI.Plugin.Widgets.Unit.Controllers"},
                    {"area", null},
                }
            };
            menuItemBuilder.ChildNodes.Add(SubMenuItem);
            return menuItemBuilder;
        } 
        #endregion
    }
}
