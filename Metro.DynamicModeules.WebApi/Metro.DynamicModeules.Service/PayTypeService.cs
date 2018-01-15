using Metro.DynamicModeules.CodeFirst.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Service.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.Service
{
    public class PayTypeService : ServiceBase<tb_PayType>
    {
        protected override object[] GetPrimaryKey(tb_PayType entity)
        {
            return new object[] { entity.PayType };
        }
        public override tb_PayType Find(object[] keyValues)
        {
            try
            {
                DbContext context = GetContext();//解决缓存问题，所以new 
                CSFramework3NormalContext normalContext = (CSFramework3NormalContext)context;
                return normalContext.tb_PayType.FirstOrDefault();//Find(keyValues);
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-Find:" + GetTableName(), e);
                return null;
            }
        }
    }
}
