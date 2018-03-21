using Metro.DynamicModeules.Common.ExpressionSerialization;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Xml.Linq;

namespace Metro.DynamicModeules.WebApi.Controllers.Sys
{
    public class ModulesController : ApiControllerBase<sys_Modules>
    {
        public override sys_Modules Find(object[] keyValues)
        {
            var module = base.Find(keyValues);
            return module;
        }

        public override sys_Modules[] GetSearchListByPage(XElement xmlPredicate, int pageSize, int pageIndex)
        {
            Expression<Func<sys_Modules, bool>> where = SerializeHelper.DeserializeExpression<sys_Modules, bool>(xmlPredicate);
            return _service.GetSearchListByPage(where, g => g.ModuleID, pageSize, pageIndex);
        }
    }
}