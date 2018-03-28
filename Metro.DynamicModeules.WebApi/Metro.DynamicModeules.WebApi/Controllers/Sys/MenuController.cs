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
    public class MenuController : ApiControllerBase<tb_MyMenu>
    {
        //public override tb_MyMenu[] GetSearchListByPage(XElement xmlPredicate, int pageSize, int pageIndex)
        //{
        //    Expression<Func<tb_MyMenu, bool>> where = SerializeHelper.DeserializeExpression<tb_MyMenu, bool>(xmlPredicate);
        //    return _service.GetSearchListByPage(where, g => g.isid, pageSize, pageIndex);
        //}

        protected override dynamic GetOrderBy()
        {
            Expression<Func<tb_MyMenu, int>> orderBy = g => g.isid;
            return orderBy;
        }
    }
}