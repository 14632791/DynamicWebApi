using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Core.Log;
using Metro.DynamicModeules.Server.DataAccess;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Server.DataAccess.DalBusiness;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.InventoryModule;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.BLL.Business;
using Metro.DynamicModeules.BLL.DataDict;
using Metro.DynamicModeules.Models.SystemModels;
using Metro.DynamicModeules.Interfaces.Sys;
using Metro.DynamicModeules.Models.BusinessModels;
using System.Linq;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.Common.Business;

/*==========================================
 *   ����˵��: InOrder��ҵ���߼���
 *   ��������: ��̩�� www.Metro.DynamicModeules.com
 *   ��������: 2015/06/16 01:41:11
 *   ����޸�: 2015/06/16 01:41:11
 *   
 *   ע: ��������ClassGenerator�Զ�����
 *   ��Ȩ���� ��̩�� www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.Business
{
    /// <summary>
    /// BllInOrder
    /// </summary>
    public class BllInOrder : BllBaseBusiness, IFuzzySearchSupportable
    {
        private IBridgeInOrder _Bridge = null;
        /// <summary>
        /// ������
        /// </summary>
        public BllInOrder()
        {
            _KeyFieldName = TblInOrder.__KeyName; //�����ֶ�
            _SummaryTableName = TblInOrder.__TableName;//����
            // _SaveVersionLog = false;//�Ƿ����ð汾����
            _Bridge = CreateBridge();
            //ʵ�����Žӹ���
        }
        private IBridgeInOrder CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectIN().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_IN();

            return null;
        }
        /// <summary>
        ///���ݵ��ݺ���Ͱ汾�Ż�ȡ�汾��ʷ��¼
        /// </summary>
        public  DataSet GetBusinessLog(string docNo, string verNo)
        {
            //_Bridge.getb
            //DataSet ds = new dalInOrder(Loginer.CurrentUser).GetBusinessLog(docNo, verNo);
            return null;
        }

        /// <summary>
        ///���ݵ��ݺ���ȡҵ������
        /// </summary>
        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            DataSet ds = _Bridge.GetBusinessByKey(keyValue);
            this.SetNumericDefaultValue(ds); //����Ԥ��ֵ
            //DataTable tblDetail=ds.Tables[TblOrderDetail.__TableName].Copy();
            //var query = (from t1 in tblDetail.AsEnumerable()
            //             join t2 in DataDictCache.Cache.CommonDataCustomer.AsEnumerable()
            //                                                  on t1.Field<string>(TblOrderDetail.WarehouseCode) equals t2.Field<string>(TblCustomer.CustomerCode)
            //             select new { t1, Tel = t2.Field<string>(TblCustomer.Tel) });
            if (resetCurrent) _CurrentBusiness = ds; //���浱ǰҵ�����ݵĶ�������
            return ds;
        }

        /// <summary>
        ///ɾ������
        /// </summary>
        public override bool Delete(string keyValue)
        {
            return _Bridge.Delete(keyValue);
        }

        /// <summary>
        ///��鵥���Ƿ����
        /// </summary>
        public bool CheckNoExists(string keyValue)
        {
            return _Bridge.CheckNoExists(keyValue);
        }

        /// <summary>
        ///��������
        /// </summary>
        public override SaveResult Save(DataSet saveData)
        {
            return _Bridge.Update(saveData); //�������ݲ㴦��     
        }

        /// <summary>
        ///��˵���
        /// </summary>
        public override void ApprovalBusiness(DataRow summaryRow)
        {
            summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
            summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
            summaryRow[BusinessCommonFields.FlagApp] = "Y";
            string key = ConvertEx.ToString(summaryRow[TblInOrder.__KeyName]);
            _Bridge.ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
        }

        /// <summary>
        ///����һ��ҵ�񵥾�
        /// </summary>
        public override void NewBusiness()
        {
            DataTable summaryTable = _CurrentBusiness.Tables[TblInOrder.__TableName];
            DataRow row = summaryTable.NewRow();
            row.BeginEdit();
            row[TblInOrder.__KeyName] = "*�Զ�����*";
            // row[TblInOrder.VerNo] = "01";
            //row[TblInOrder.CreatedBy] = Loginer.CurrentUser.Account;
            //row[TblInOrder.CreationDate] = DateTime.Now;
            //row[TblInOrder.LastUpdatedBy] = Loginer.CurrentUser.Account;
            //row[TblInOrder.LastUpdateDate] = DateTime.Now;
            row.EndEdit();
            summaryTable.Rows.Add(row);
        }

        /// <summary>
        ///�������ڱ������ʱ����,ͬʱ������ϸ��Ĺ����ֶ�����
        /// </summary>
        public override DataSet CreateSaveData(DataSet currentBusiness, UpdateType currentType)
        {
            //if (DataBindRow.RowState != DataRowState.Unchanged)
            //{
            //    this.UpdateSummaryRowState(this.DataBindRow, currentType);
            //}
            ////�������ڱ������ʱ����,���������������
            //DataSet save = this.DoCreateTempData(currentBusiness, TblInOrder.__TableName);
            //if (save.Tables.Count > 0)
            //{
            //    DataTable summary = save.Tables[0];
            //    summary.Rows[0][BusinessCommonFields.LastUpdateDate] = DateTime.Now;
            //    summary.Rows[0][BusinessCommonFields.LastUpdatedBy] = Loginer.CurrentUser.Account;
            //}
           // DataTable detail = currentBusiness.Tables[TblOrderDetail.__TableName].Copy();
            this.UpdateDetailCommonValue(currentBusiness.Tables[TblOrderDetail.__TableName]); //������ϸ��Ĺ����ֶ�����
            this.UpdateDetailCommonValue(currentBusiness.Tables[TblDeliveryInfo.__TableName]);
            //save.Tables.Add(detail); //������ϸ���� 
            return currentBusiness.Copy();
        }

        /// <summary>
        ///��ѯ����
        /// </summary>
        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo,OrderStatus status=0)
        {
            return _Bridge.GetSummaryByParam(docNoFrom, docNoTo, docDateFrom, docDateTo, (int)status);
        }

        //protected override void SetDefault(DataTable data)
        //{
        //    //˾��������Ĭ��ֵ
        //    data.Columns[TblInOrder.IsDelete].DefaultValue = 0;
        //}

        /// <summary>
        ///��ȡ��������
        /// </summary>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            return null;
        }
        #region Business Log

        /// <summary>
        /// д����־
        /// </summary>
        //public override void WriteLog()
        //{
        //    base.WriteLog();
        //    //string key = this.DataBinder.Rows[0][TblInOrder.__KeyName].ToString();//ȡ���ݺ���
        //    //DataSet dsOriginal = this.GetBusinessByKey(key, false); //ȡ����ǰ��ԭʼ����, ���ڱ�����־ʱƥ������.
        //    //DataSet dsTemplate = this.CreateSaveData(this.CurrentBusiness, UpdateType.Modify); //�������ڱ������ʱ����
        //    //this.WriteLog(dsOriginal, dsTemplate);//������־      
        //}

        ///// <summary>
        ///// д����־
        ///// </summary>
        ///// <param name="original">ԭʼ����</param>
        ///// <param name="changes">�޸ĺ������</param>
        //public override void WriteLog(DataTable original, DataTable changes)
        //{
        //    try
        //    {
        //        string logID = Guid.NewGuid().ToString().Replace("-", ""); //������־ID
        //        IBridgeEditLogHistory logBridge = BllBusinessLog.CreateEditLogHistoryBridge();
        //        logBridge.WriteLog(logID, original, changes, TblInOrder.__TableName, TblInOrder.__KeyName, true); //����
        //        //  logBridge.WriteLog(logID, original.Tables[1], changes.Tables[1], TblInOrder.__TableName, TblInOrder.__KeyName, false);//��ϸ
        //    }
        //    catch
        //    {
        //        Msg.Warning("д����־��������");
        //    }
        //}

        ///// <summary>
        ///// д����־
        ///// </summary>
        ///// <param name="original">ԭʼ����</param>
        ///// <param name="changes">�޸ĺ������</param>
        //public override void WriteLog(DataSet original, DataSet changes)
        //{
        //    WriteLog(original.Tables[0], changes.Tables[0]);
        //}

        /// <summary>
        /// �µ������Ǹı䶩��״̬Ϊ1 2015.7.10
        /// </summary>
        /// <param name="OrderNo">��������</param>
        /// <returns></returns>
        public bool Generate(string OrderNo,int iStatus=1)
        {
          return  _Bridge.Generate(OrderNo, iStatus);
        }

        #endregion

        #region IFuzzySearchSupportable Members

        public string FuzzySearchName
        {
            get { return "������Ʒ����"; }
        }

        public DataTable FuzzySearch(string content)
        {
            BllProduct Bll = new BllProduct();
            return Bll.FuzzySearch(content);
        }

        public DataTable FuzzySearchInOrder(string content)
        {
            return _Bridge.FuzzySearch(content);
        }
        #endregion
    }
}
