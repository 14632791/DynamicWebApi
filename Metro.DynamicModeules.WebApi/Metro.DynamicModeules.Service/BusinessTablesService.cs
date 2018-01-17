using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Service.Base;

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
