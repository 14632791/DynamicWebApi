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
        /// 模块主窗体的菜单
        /// </summary>
        /// <returns></returns>
        //ObservableCollection<MenuModel> Menus { get; set; }

        /// <summary>
        /// 模块主窗体功能按钮所在的容器 
        /// </summary>
        /// <returns></returns>
        Control Container { get; set; }

        /// <summary>
        /// 要显示的图标
        /// </summary>
        object Icon { get; set; }
        /// <summary>
        /// 设置模块的权限
        /// </summary>
        /// <param name="securityInfo">权限信息</param>
        void SetSecurity(object securityInfo);

        /// <summary>
        /// 初始化模块主窗体的按钮
        /// </summary>
        void InitButton();

        /// <summary>
        /// 初始化模块主窗体的菜单
        /// </summary>
        void InitMenu();

        void Initialize();
    }
    
    }
