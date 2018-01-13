using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Service.Base;
using System;
using System.Collections.Generic;
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
    }
}
