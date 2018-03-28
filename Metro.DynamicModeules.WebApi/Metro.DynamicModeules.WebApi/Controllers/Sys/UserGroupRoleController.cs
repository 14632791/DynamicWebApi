using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Models.Sys;
using System.Xml.Linq;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using System.Linq.Expressions;

namespace Metro.DynamicModeules.WebApi.Controllers.Sys
{
    public class UserGroupRoleController : ApiControllerBase<tb_MyUserGroupRole>
    {
        //public override tb_MyUserGroupRole[] GetSearchListByPage(XElement xmlPredicate, int pageSize, int pageIndex)
        //{
        //    Expression<Func<tb_MyUserGroupRole, bool>> where = SerializeHelper.DeserializeExpression<tb_MyUserGroupRole, bool>(xmlPredicate);
        //    return _service.GetSearchListByPage(where, g => g.CreatedTime, pageSize, pageIndex);
        //}
        protected override dynamic GetOrderBy()
        {
            Expression<Func<tb_MyUserGroup, DateTime?>> orderBy = g => g.CreatedTime;
            return orderBy;
        }
    }
}