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
        /// 删除记录
        /// </summary>
        /// <param name="row"></param>
        void DoDelete();// T row);

        /// <summary>
        /// 系统关闭
        /// </summary>
        /// <returns></returns>
        void DoClose();

        /// <summary>
        /// 关闭窗体
        /// </summary>
        void DoCloseBox();

        void DoHistory();

        void DoApprove();

        /// <summary>
        /// 变更
        /// </summary>
        void DoChange();

        /// <summary>
        /// 显示帮助信息
        /// </summary>
        void DoHelp();

        /// <summary>
        /// 打印
        /// </summary>
        void DoPrint();

        /// <summary>
        /// 打印预览 = 64
        /// </summary>
        void DoPreview();

        /// <summary>
        /// 作废 = 128
        /// </summary>
        void DoTrashSolid();

        /// <summary>
        /// 生成单据 = 256
        /// </summary>
        void DoReceipt();

        /// <summary>
        /// 复制单据 = 512
        /// </summary>
        void DoCopySolid();

        /// <summary>
        /// 导出单据 = 1024
        /// </summary>
        void DoExport();

        /// <summary>
        /// 锁定 = 2048
        /// </summary>
        void DoLock();

        /// <summary>
        /// 保存 = 4096
        /// </summary>
        void DoSave();

        /// <summary>
        /// 附件管理 = 8192
        /// </summary>
        void DoAttachment();

        /// <summary>
        /// 查看版本历史 = 16384
        /// </summary>
        void DoVersions();

        /// <summary>
        /// 查询 = 16384 * 2,
        /// </summary>
        void DoSearch();
        /// <summary>
        /// 当前操作状态
        /// </summary>
        UpdateType UpdateType { get; }

        /// <summary>
        /// 当前要操作的数据
        /// </summary>
        object Data { get; set; }

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
