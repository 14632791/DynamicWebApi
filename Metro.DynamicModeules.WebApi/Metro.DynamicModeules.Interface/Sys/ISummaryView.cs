using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    /// 数据窗体主表资料显示视图
    /// </summary>
    public interface ISummaryView<T> where T : class, new()
    {
       

        /// <summary>
        /// 数据源
        /// </summary>
        ObservableCollection<T> DataSource { get; set; }

        /// <summary>
        /// 关联的视图对象(如DataGridView,GridView,TreeView)
        /// </summary>
        ListCollectionView View { get; }

        /// <summary>
        /// 当前选中行
        /// </summary>
        T FocusedRow { get; set; }

        /// <summary>
        /// 刷新数据源，重新显示数据
        /// </summary>
        void RefreshDataSource();
    }
}
