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
        /// 记录数
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// 当前选中的资料行
        /// </summary>
        int FocusedRowHandle { get; set; }

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


        /// <summary>
        /// 移动到第一条记录
        /// </summary>
        void MoveFirst();

        /// <summary>
        /// 移动到前一条记录
        /// </summary>
        void MovePrior();

        /// <summary>
        /// 移动到下一条记录
        /// </summary>
        void MoveNext();

        /// <summary>
        /// 移动到最后一条记录
        /// </summary>
        void MoveLast();



    }
}
