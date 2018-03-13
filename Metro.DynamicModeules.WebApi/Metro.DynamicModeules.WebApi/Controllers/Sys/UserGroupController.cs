using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Models.Sys;
using Metro.DynamicModeules.Service;
using System.Web.Http;

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
    }
}