﻿///*************************************************************************/
///*
///* 文件名    ：BllBaseBusiness.cs                                      
///* 程序说明  : 业务单据逻辑层基类
///* 原创作者  ：陈刚
///* 
///* Copyright 2015 Metro.DynamicModeules software
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.SystemModule;
using Metro.DynamicModeules.Models.SystemModels;
using Metro.DynamicModeules.Interfaces.Sys;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.BLL.Business;

namespace Metro.DynamicModeules.BLL.Base
{
    /// <summary>
    /// 业务单据的业务逻辑层基类. 实现ILogSupportable接口(修改日志功能)
    /// </summary>
    public abstract class BllBaseBusiness : BllBase, ILogSupportable
    {

        /// <summary>
        /// 当前正在处理的业务数据
        /// </summary>
        protected DataSet _CurrentBusiness = null;

        /// <summary>
        /// 业务单据的主键
        /// </summary>
        protected string _KeyFieldName = string.Empty;

        /// <summary>
        /// 业务单据的主表名称
        /// </summary>
        protected string _SummaryTableName = string.Empty;

        /// <summary>
        /// 业务单据的主键字段名
        /// </summary>
        public string KeyFieldName { get { return _KeyFieldName; } set { _KeyFieldName = value; } }

        /// <summary>
        /// 业务单据的主表名称
        /// </summary>
        public string SummaryTableName { get { return _SummaryTableName; } set { _SummaryTableName = value; } }

        /// <summary>
        /// 当前正在处理的业务数据
        /// </summary>        
        public DataSet CurrentBusiness { get { return _CurrentBusiness; } }

        /// <summary>
        /// 当前正在处理的业务数据. 第1个表为主表,
        /// </summary>  
        public DataTableCollection BusinessTables { get { return _CurrentBusiness.Tables; } }

        /// <summary>
        /// 当前数据绑定对象(DataTable)
        /// 该表只有一条记录，用于数据修改页面(TabPage)的数据绑定。
        /// </summary>
        public DataTable DataBinder { get { return _CurrentBusiness.Tables[0]; } }

        /// <summary>
        /// 当前数据绑定DataTable的第一条记录
        /// </summary>
        public DataRow DataBindRow { get { return _CurrentBusiness.Tables[0].Rows[0]; } }

        /// <summary>
        /// 获取单据附件数据
        /// </summary>
        /// <param name="docNo">单据号码</param>
        /// <returns></returns>
        public virtual DataTable GetAttachedFiles(string docNo)
        {
            if ((_CurrentBusiness == null) || (_CurrentBusiness.Tables[TblAttachFile.__TableName] == null))
            {
                DataTable attachedFiles;

                //跟据单号下载附件数据
                IBridgeAttachFile bridge = this.CreateAttachFileBridge();
                attachedFiles = bridge.GetData(docNo);
                attachedFiles.TableName = TblAttachFile.__TableName;

                //附件数据作为业务单据的一张明细表
                if (_CurrentBusiness != null) _CurrentBusiness.Tables.Add(attachedFiles.Copy());
            }
            return _CurrentBusiness.Tables[TblAttachFile.__TableName];
        }


        /// <summary>
        /// 创建业务单据附件管理的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        private IBridgeAttachFile CreateAttachFileBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectAttachFile().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebServiceAttachFile();

            throw new CustomException("UNKNOW_BRIDGE_TYPE:CreateAttachFileBridge()");
        }

        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="storage">附件数据</param>
        public void SaveAttachedFile(DataTable storage)
        {
            DataTable temp = storage.GetChanges(); //获取修改的记录
            if (temp != null)//有新增或修改附件，保存数据
            {
                IBridgeDataDict bridge = BridgeFactory.CreateDataDictBridge(typeof(TblAttachFile));
                DataSet ds = new DataSet();
                ds.Tables.Add(temp);
                bridge.Update(ds);
            }
        }

        /// <summary>
        /// 新增业务数据
        /// </summary>
        public abstract void NewBusiness();

        /// <summary>
        /// 删除业务数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public abstract bool Delete(string keyValue);

        /// <summary>
        /// 保存业务数据
        /// </summary>
        /// <param name="saveData">业务数据</param>
        /// <returns>返回保存状态</returns>
        public abstract SaveResult Save(DataSet saveData);

        /// <summary>
        /// 由指定单号下载业务数据
        /// </summary>
        /// <param name="keyValue">单据号码(主键值)</param>
        /// <param name="resetCurrent">是否更新当前业务对象的数据引用</param>
        /// <returns>返回DataSet</returns>
        public abstract DataSet GetBusinessByKey(string keyValue, bool resetCurrent);

        /// <summary>
        /// 创建用于保存的临时数据，同时更新明细表的公共字段数据
        /// </summary>
        /// <param name="sourceData">原始数据</param>
        /// <param name="currentType">当前操作状态</param>
        /// <returns></returns>
        public abstract DataSet CreateSaveData(DataSet sourceData, UpdateType currentType);

        /// <summary>
        /// 更新记录状态
        /// </summary>
        /// <param name="dataRow">当前记录</param>
        /// <param name="currentType">状态类型</param>
        protected void UpdateSummaryRowState(DataRow dataRow, UpdateType currentType)
        {
            dataRow.AcceptChanges();
            if (currentType == UpdateType.Modify) dataRow.SetModified();
            if (currentType == UpdateType.Add) dataRow.SetAdded();
        }

        /// <summary>
        ///创建一个用于保存的临时数据集
        /// </summary>
        /// <param name="currentBusiness">当前业务数据</param>
        /// <param name="summaryTableName">主表的表名</param>
        /// <returns></returns>
        protected virtual DataSet DoCreateTempData(DataSet currentBusiness, string summaryTableName)
        {
            DataSet tempDS = new DataSet();
            //保存主表记录状态
            DataRowState state = currentBusiness.Tables[summaryTableName].Rows[0].RowState;
            currentBusiness.Tables[summaryTableName].AcceptChanges(); //保存临时数据,待保存OK后再提交改变
            //创建一个副本
            DataTable summary = currentBusiness.Tables[summaryTableName].Copy();
            //设为原来的记录状态
            switch (state)
            {
                case DataRowState.Added:
                    summary.Rows[0].SetAdded();
                     tempDS.Tables.Add(summary);//插入主表数据
                    break;
                case DataRowState.Modified:
                    summary.Rows[0].SetModified();
                     tempDS.Tables.Add(summary);//插入主表数据
                    break;
                case DataRowState.Unchanged:
                    break;//因为没有改动，所以什么都不用做
                default:
                    break;
            }
            return tempDS;
        }

        /// <summary>
        /// 检查业务主表的当前记录是否已审核
        /// </summary>
        /// <param name="summaryRow">业务主表的当前记录</param>
        /// <returns></returns>
        public virtual bool IsApproved(DataRow summaryRow)
        {
            if (summaryRow == null) return false;

            return (ConvertEx.ToString(summaryRow[BusinessCommonFields.FlagApp]).ToUpper() == "Y")
            && (ConvertEx.ToString(summaryRow[BusinessCommonFields.AppUser]).ToUpper() != "");
        }

        /// <summary>
        /// 比较当前用户与制单人是否一致
        /// </summary>
        /// <param name="summaryRow">业务主表的当前记录</param>
        /// <returns></returns>
        public bool IsOwnerChange(DataRow summaryRow)
        {
            string user = ConvertEx.ToString(summaryRow[BusinessCommonFields.CreatedBy]); //取制单人
            return user.ToUpper() == Loginer.CurrentUser.Account.ToUpper(); //比较当前用户与制单人是否一致
        }

        /// <summary>
        /// 审核/批准
        /// </summary>
        /// <param name="summaryRow">业务主表的当前记录</param>
        public virtual void ApprovalBusiness(DataRow summaryRow) { }

        /// <summary>
        /// 取消 审核/批准
        /// </summary>
        /// <param name="summaryRow">业务主表的当前记录</param>
        public virtual void ClearAppInfo(DataRow summaryRow)
        {
            summaryRow[BusinessCommonFields.FlagApp] = DBNull.Value;
            summaryRow[BusinessCommonFields.AppUser] = DBNull.Value;
            summaryRow[BusinessCommonFields.AppDate] = DBNull.Value;
        }

        /// <summary>
        /// 更新业务单据明细表的共同字段数据
        /// </summary>
        /// <param name="detail">明细表</param>
        protected virtual void UpdateDetailCommonValue(DataTable detail)
        {
            foreach (DataRow row in detail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                if (row.RowState == DataRowState.Added)
                {
                    row.BeginEdit();
                    row[BusinessDetailCommonFields.CreatedBy] = Loginer.CurrentUser.Account;
                    row[BusinessDetailCommonFields.CreationDate] = DateTime.Now;
                    row[BusinessDetailCommonFields.LastUpdatedBy] = Loginer.CurrentUser.Account;
                    row[BusinessDetailCommonFields.LastUpdateDate] = DateTime.Now;
                    row.EndEdit();
                }
                if (row.RowState == DataRowState.Modified)
                {
                    row.BeginEdit();
                    row[BusinessDetailCommonFields.LastUpdatedBy] = Loginer.CurrentUser.Account;
                    row[BusinessDetailCommonFields.LastUpdateDate] = DateTime.Now;
                    row.EndEdit();
                }
            }
        }

        #region 写入日志

        /// <summary>
        /// 写入日志 2015.7.10 内容是新增加的 陈刚
        /// </summary>
        public virtual void WriteLog()
        {
            BllBusinessLog.WriteLog(CurrentBusiness.GetChanges(), Loginer.CurrentUser.Account);
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="original">原始数据</param>
        /// <param name="changes">修改后的数据</param>
      //  public abstract void WriteLog(DataTable original, DataTable changes);
       
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="original">原始数据</param>
        /// <param name="changes">修改后的数据</param>
      //  public abstract void WriteLog(DataSet original, DataSet changes);
        #endregion

        /// <summary>
        /// 发送手机短信或Email通知用户
        /// </summary>
        public virtual void NotifyUser()
        {
            //发送手机短信或Email
        }
    }
}
