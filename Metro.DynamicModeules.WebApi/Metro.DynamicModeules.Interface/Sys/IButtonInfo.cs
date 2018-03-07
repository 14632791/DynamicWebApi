using MahApps.Metro.IconPacks;
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
        /// 按钮名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 按钮标题
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// 按钮矢量图片类型
        /// </summary>
        PackIconControl<object> Icon { get; set; }
        
        /// <summary>
        /// 显示顺序
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// 按钮对象
        /// </summary>
        object Button { get; }
        

        /// <summary>
        /// 按钮权限值
        /// </summary>
        int Authority { get; set; }

      
    }
}
