using System.Collections.ObjectModel;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// Mid主窗体接口
    /// </summary>
    public interface IMdiMainWindow
    {
        #region 右下方的tabItems列表
        ObservableCollection<IMdiChildView> TabPages { get; set; }
        #endregion
        /// <summary>
        /// 当前选中的page
        /// </summary>
        IMdiChildView FocusedPage { get; set; }
    }
}
