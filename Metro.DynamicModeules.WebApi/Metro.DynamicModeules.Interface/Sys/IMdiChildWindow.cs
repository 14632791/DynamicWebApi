using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// MDI子窗体的接口
    /// </summary>
    public interface IMdiChildWindow: IModuleBase
    {  

        /// <summary>
        /// 子窗体的按钮列表
        /// </summary>
        ObservableCollection<IButtonInfo> Buttons { get; }

        /// <summary>
        /// 初始化子窗体的按钮
        /// </summary>
        void InitButtons();

        
    }

    /// <summary>
    /// 系统预设按钮(如：关闭和帮助按钮)
    /// </summary>
    public interface ISystemButtons
    {
        List<IButtonInfo> GetSystemButtons();
        void DoClose(IButtonInfo button); //关闭窗体
        void DoHelp(IButtonInfo button); //打开帮助
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
        List<IButtonInfo> GetPrintableButtons();
        /// <summary>
        /// 打开打印窗体
        /// </summary>
        /// <param name="button"></param>
        void DoPrint(IButtonInfo button);
    }

    
}
