using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Service;
using System.Xml.Linq;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using System.Linq.Expressions;

namespace Metro.DynamicModeules.WebApi.Controllers
{
    public class SysBusinessTablesController : ApiControllerBase<sys_BusinessTables>
    {
        //public override sys_BusinessTables[] GetSearchListByPage(XElement xmlPredicate, int pageSize, int pageIndex)
        //{
        //    Expression<Func<sys_BusinessTables, bool>> where = SerializeHelper.DeserializeExpression<sys_BusinessTables, bool>(xmlPredicate);
        //    return _service.GetSearchListByPage(where, g => g.isid, pageSize, pageIndex);
        //}
        protected override dynamic GetOrderBy()
        {
            Expression<Func<tb_PayType, int>> orderBy = g => g.isid;
            return orderBy;
        }
        protected override ServiceBase<sys_BusinessTables> GetService()
        {
            return new BusinessTablesService();
        }
    }
}
