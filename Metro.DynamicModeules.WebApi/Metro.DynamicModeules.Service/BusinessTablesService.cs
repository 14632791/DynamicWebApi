using Metro.DynamicModeules.CodeFirst.Models;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Metro.DynamicModeules.Service
{
    public class BusinessTablesService : ServiceBase<sys_BusinessTables>
    {
        public BusinessTablesService()
        {
        }

        protected override object[] GetPrimaryKey(sys_BusinessTables entity)
        {
            return new object[] { entity.isid };
        }
    }
}
