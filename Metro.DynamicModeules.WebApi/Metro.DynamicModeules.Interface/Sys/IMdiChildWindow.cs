using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// MDI子窗体的接口
    /// </summary>
    public interface IMdiChildWindow
    {
        PackIconControl<object> Icon { get; set; }
       // string FormMenuName { get; set; }
        /// <summary>
        /// 登记子窗体的观察者
        /// </summary>
        /// <param name="observers">所有观察者</param>
       // void RegisterObserver(IObserver[] observers);

        /// <summary>
        /// 子窗体的按钮列表
        /// </summary>
        List<IButtonInfo> Buttons { get; }

        /// <summary>
        /// 初始化子窗体的按钮
        /// </summary>
        void InitButtons();

        /// <summary>
        /// 窗体是否进入关闭状态
        /// </summary>
       // bool IsClosing { get; set; }

        /// <summary>
        /// 是否允许打开多个子窗体实例
        /// </summary>
       // bool AllowMultiInstatnce { get; set; }
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

    /// <summary>
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 发送通知
        /// </summary>
        void Notify();
    }
}
