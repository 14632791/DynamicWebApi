using Metro.DynamicModeules.Models.Sys;
using Metro.DynamicModeules.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.Service
{
    public class UserGroupService : ServiceBase<tb_MyUserGroup>
    {
        /// <summary>
        /// 通过用户账号返回相关的组
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public IEnumerable<tb_MyUserGroup> GetGroupsByAccount(string userAccount)
        {
            return GetSearchList(g => g.tb_MyUser.Any(u => u.Account == userAccount));
        }
    }
}
