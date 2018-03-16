using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Metro.DynamicModeules.Interface.Sys
{
    public interface IButtonInfo
    {
        tb_MyAuthorityItem AuthorityItem
        {
            get; set;
        }
        /// <summary>
        /// 是否启动
        /// </summary>
        bool IsEnabled
        {
            get; set;
        }
        /// <summary>
        /// 图标
        /// </summary>
        object Icon
        {
            get; set;
        }
        int Index
        {
            get;
            set;
        }
        ICommand ClickCommand { get; }
    }
}
