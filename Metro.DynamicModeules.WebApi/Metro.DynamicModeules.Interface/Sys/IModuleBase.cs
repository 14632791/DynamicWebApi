﻿using Metro.DynamicModeules.Models.Sys;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// 模块主窗体接口
    /// </summary>
    public interface IModuleBase: ICommonModuleBase
    {
        /// <summary>
        /// 模块信息
        /// </summary>
        /// <returns></returns>
        sys_Modules Module { get; set; }

        /// <summary>
        /// 初始化所有子界面
        /// </summary>
        void InitMenu();
        ObservableCollection<IMdiChildViewModel> SubModuleList { get; set; }
        IMdiChildViewModel FocusedChild { get; set; }
    }

    /// <summary>
    /// 构件的通用接口
    /// </summary>
    public interface ICommonModuleBase
    {
        /// <summary>
        /// 该模块的窗体
        /// </summary>
        /// <returns></returns>
        Control Owner { get; set; }

        /// <summary>
        /// 要显示的图标
        /// </summary>
        object Icon { get; set; }

        /// <summary>
        /// 宿主窗体
        /// </summary>
        IMdiMainViewModel MdiMainWindow { get; set; }

       
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
    }
}
