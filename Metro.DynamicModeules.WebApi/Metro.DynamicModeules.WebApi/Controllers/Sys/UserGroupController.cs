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

        /// <summary>
        /// 获取该用户对应的所有组
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public IEnumerable<tb_MyUserGroup> GetGroupsByAccount([FromBody]string userAccount)
        {
            return _groupService.GetGroupsByAccount(userAccount);
        }
        
        /// <summary>
        /// 通过组code获取与用户的对应关系
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public IEnumerable<tb_MyUserGroupRe> GetUserRelationByGroup([FromBody] string groupCode)
        {
            return _groupService.GetUserRelationByGroup(groupCode);
        }
        protected override dynamic GetOrderBy()
        {
            Expression<Func<tb_MyUserGroup, DateTime?>> orderBy = g => g.CreatedTime;
            return orderBy;
        }
    }
}