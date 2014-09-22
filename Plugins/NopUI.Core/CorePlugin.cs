

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
       
        #region ��װ
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            base.Install();
        } 
        #endregion

        #region ж��
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
    /// ��������ӿ�
    /// </summary>
    public static class PublicInterface
    {
        /// <summary>
        /// �жϺ��Ĳ����û�а�װ
        /// </summary>
        /// <returns></returns>
        public static bool IsInstall() {
            var _pluginFinder = EngineContext.Current.ContainerManager.Resolve<IPluginFinder>();
            var descriptor = _pluginFinder.GetPluginDescriptorBySystemName<IPlugin>("NopUI.Core");
            if (descriptor == null)
            {
                return false;
                //��ʾ���Ĳ��û�а�װ��������װ
                //throw new NopException("���Ĳ��û�а�װ��������װ");
            }
            return true;
        }
    }
}
