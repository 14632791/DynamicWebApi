using System.Collections.ObjectModel;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// Mid主窗体接口
    /// </summary>
    public interface IMdiMainViewModel
    {
        #region 右下方的tabItems列表
        ObservableCollection<IMdiChildViewModel> TabPages { get; set; }
        #endregion
        /// <summary>
        /// 当前选中的page
        /// </summary>
        IMdiChildViewModel FocusedPage { get; set; }
        ObservableCollection<IModuleBase> Modules { get; set; }
    }

    /// <summary>
    /// 主界面的载体
    /// </summary>
    public interface IHost
    {
        /// <summary>
        /// 需要加载的模块
        /// </summary>
        /// <param name="info"></param>
        void Exec();

        /// <summary>
        /// 显示加载进度
        /// </summary>
        /// <param name="msg"></param>
        void ShowProgress(string msg);
    }
}
