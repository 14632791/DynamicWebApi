using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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
        sys_Modules Module { get; }



        /// <summary>
        /// 模块主窗体的菜单
        /// </summary>
        /// <returns></returns>
        MenuItem GetModuleMenu();

        /// <summary>
        /// 模块主窗体功能按钮所在的容器 
        /// </summary>
        /// <returns></returns>
        Control GetContainer();

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
