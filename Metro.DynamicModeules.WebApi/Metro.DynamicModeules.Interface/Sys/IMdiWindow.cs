using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Metro.DynamicModeules.Interface.Sys
{

    /// <summary>
    /// MDI主窗体接口,每个模块唯一的主界面
    /// </summary>
    public interface IMdiWindow
    {
        /// <summary>
        ///主窗体的工具栏 
        /// </summary>
        //IToolbarRegister MdiToolbar { get; set; }

        /// <summary>
        /// 主窗体的观察者
        /// </summary>
        IObserver[] MdiObservers { get; }

        /// <summary>
        /// 注册主窗体工具栏的按钮
        /// </summary>
        void RegisterMdiButtons();

        /// <summary>
        /// 主窗体上的按钮集合
        /// </summary>
        IList<IButtonInfo> MdiButtons { get; }

        /// <summary>
        /// 所有模块主菜单的集合
        /// </summary>
        MenuItem MainMenu { get; }
        
        /// <summary>
        /// 显示模块的主窗体
        /// </summary>
        void ShowModuleContainerForm();
    }
}
