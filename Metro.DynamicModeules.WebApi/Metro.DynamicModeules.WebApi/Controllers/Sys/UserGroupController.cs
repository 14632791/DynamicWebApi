using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Models.Sys;
using Metro.DynamicModeules.Service;
using System.Web.Http;
using System.Xml.Linq;
using System.Linq.Expressions;
using Metro.DynamicModeules.Common.ExpressionSerialization;

namespace Metro.DynamicModeules.WebApi.Controllers.Sys
{
    public class UserGroupController : ApiControllerBase<tb_MyUserGroup>
    {
        UserGroupService _groupService;
        protected override ServiceBase<tb_MyUserGroup> GetService()
        {
            _groupService = new UserGroupService();
            return _groupService;
        }
        [System.Web.Http.HttpPost]
        public IEnumerable<tb_MyUserGroup> GetGroupsByAccount([FromBody]string userAccount)
        {
            return _groupService.GetGroupsByAccount(userAccount);
        }

        public override tb_MyUserGroup[] GetSearchListByPage(XElement xmlPredicate, int pageSize, int pageIndex)
        {
            Expression<Func<tb_MyUserGroup, bool>> where = SerializeHelper.DeserializeExpression<tb_MyUserGroup, bool>(xmlPredicate);
             return _service.GetSearchListByPage(where, g=>g.CreatedTime, pageSize, pageIndex);
        }
    }
}