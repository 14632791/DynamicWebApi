using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Service.Base;
using System;
using System.Linq;

namespace Metro.DynamicModeules.Service
{
    public class PayTypeService : ServiceBase<tb_PayType>
    {

        //public override tb_PayType Find(object[] keyValues)
        //{
        //    try
        //    {
        //        var pay = base.Find(keyValues);
        //        var keys = GetPrimaryKey(pay);
        //        var tname = GetTableName();
        //        return pay;
        //    }
        //    catch (Exception e)
        //    {
        //        LogHelper.Error("BaseService-Find:" + GetTableName(), e);
        //        return null;
        //    }
        //}
    }
}
