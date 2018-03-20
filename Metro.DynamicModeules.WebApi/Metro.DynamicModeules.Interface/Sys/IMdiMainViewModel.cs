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
    }
}
