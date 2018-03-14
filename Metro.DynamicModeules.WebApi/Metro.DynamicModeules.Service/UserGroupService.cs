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
        public UserGroupService()
        {
        }
        /// <summary>
        /// 通过用户账号返回相关的组
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public IEnumerable<tb_MyUserGroup> GetGroupsByAccount(string userAccount)
        {
            NormalEntity normalContext = (NormalEntity)DbContext;
            try
            {
                var gups = from g in normalContext.tb_MyUserGroup
                           where (from r in normalContext.tb_MyUserGroupRe
                                  where r.Account.Equals(userAccount)
                                  select r.GroupCode).
                           Distinct().Contains(g.GroupCode)
                           select g;
                return gups.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                normalContext.Dispose();
            }
        }
    }
}
