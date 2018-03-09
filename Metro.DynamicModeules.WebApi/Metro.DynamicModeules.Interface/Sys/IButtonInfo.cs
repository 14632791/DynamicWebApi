using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Metro.DynamicModeules.Interface.Sys
{

    /// <summary>
    /// 自定义按钮接口
    /// </summary>
    public interface IButtonInfo
    {
        /// <summary>
        /// 对应的实体
        /// </summary>
        tb_MyAuthorityItem MyAuthorityItem { get; set; }


        /// <summary>
        /// 按钮矢量图片类型
        /// </summary>
        PackIconControl<object> Icon { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// 要执行的action
        /// </summary>
        ICommand ClickCommand { get;}

    }
}
