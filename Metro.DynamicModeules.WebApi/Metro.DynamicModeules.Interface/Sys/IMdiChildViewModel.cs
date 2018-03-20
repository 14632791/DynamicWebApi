using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// MDI子窗体的接口
    /// </summary>
    public interface IMdiChildViewModel: ICommonModuleBase
    {
        IModuleBase IModule { get; set; }
        /// <summary>
        /// 打开窗口command
        /// </summary>
        ICommand OpenOwnerCommand { get; }
        /// <summary>
        /// 关闭窗口command
        /// </summary>
        ICommand CloseCommand { get; }

        /// <summary>
        /// 子窗体的按钮列表
        /// </summary>
        IList<IButtonInfo> Buttons { get; set; }
        

        tb_MyMenu MyMenu { get; set; }
    }

    /// <summary>
    /// 系统预设按钮(如：关闭和帮助按钮)
    /// </summary>
    public interface ISystemButtons
    {
        IList GetSystemButtons();
        void DoClose( ); //关闭窗体
        void DoHelp( ); //打开帮助
    }

    /// <summary>
    /// 支持打印功能的接口
    /// </summary>
    public interface IPrintableForm
    {
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <returns></returns>
        IList GetPrintableButtons();
        /// <summary>
        /// 打开打印窗体
        /// </summary>
        /// <param name="button"></param>
        void DoPrint();
    }

    
}
