using System.Collections;
using System.Collections.Generic;

namespace Metro.DynamicModeules.Interface.Sys
{
    /// <summary>
    ///  支持数据操作的接口
    /// </summary>
    public interface IDataOperatable//<T> where T : class, new()
    {
        /// <summary>
        /// 返回数据操作窗体的按钮
        /// </summary>
        /// <returns></returns>
        IList GetDataOperatableButtons();

        /// <summary>
        /// 查看/显示数据
        /// </summary>
        /// <param name="button"></param>
        void DoViewContent();//查看数据

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="row"></param>
        void DoAdd();// T row);

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="row"></param>
        void DoEdit();// T row);

        /// <summary>
        /// 取消新增或修改
        /// </summary>
        /// <param name="row"></param>
        void DoCancel();// T row);

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="row"></param>
        bool DoSave();// T row);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="row"></param>
        bool DoDelete();// T row);

        /// <summary>
        /// 当前操作状态
        /// </summary>
        UpdateType UpdateType { get; }

        /// <summary>
        /// 是否修改了数据
        /// </summary>
        bool DataChanged { get; }

        /// <summary>
        /// 是否允许数据操作
        /// </summary>
        bool AllowDataOperate { get; set; }
    }
}
