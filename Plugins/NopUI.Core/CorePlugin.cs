

using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;


namespace NopUI.Core
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class CorePlugin : BasePlugin
    {
       
        #region 安装
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            base.Install();
        } 
        #endregion

        #region 卸载
        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            base.Uninstall();
        } 
        #endregion
    }

    /// <summary>
    /// 公共对外接口
    /// </summary>
    public static class PublicInterface
    {
        /// <summary>
        /// 判断核心插件有没有安装
        /// </summary>
        /// <returns></returns>
        public static bool IsInstall() {
            var _pluginFinder = EngineContext.Current.ContainerManager.Resolve<IPluginFinder>();
            var descriptor = _pluginFinder.GetPluginDescriptorBySystemName<IPlugin>("NopUI.Core");
            if (descriptor == null)
            {
                return false;
                //表示核心插件没有安装，不允许安装
                //throw new NopException("核心插件没有安装，不允许安装");
            }
            return true;
        }
    }
}
