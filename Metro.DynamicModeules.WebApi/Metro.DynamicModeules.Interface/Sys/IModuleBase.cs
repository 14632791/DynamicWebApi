using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// 模块主窗体接口
    /// </summary>
    public interface IModuleBase
    {
        /// <summary>
        /// 模块信息
        /// </summary>
        /// <returns></returns>
        sys_Modules Module { get; set; }


        /// <summary>
        /// 该模块的窗体
        /// </summary>
        /// <returns></returns>
        Control Owner { get; set; }

        /// <summary>
        /// 要显示的图标
        /// </summary>
        object Icon { get; set; }

        IMdiMainWindow MdiMainWindow { get; set; }

        void InitMenu();
        void Initialize();
    }

}
