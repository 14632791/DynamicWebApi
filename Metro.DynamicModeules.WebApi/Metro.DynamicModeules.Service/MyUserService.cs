using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interface.Service;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using Metro.DynamicModeules.Service.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.Service
{
    public class MyUserService : ServiceBase<tb_MyUser>, IMyUser
    {
        /// <summary>
        /// 实体查询
        /// </summary>
        public tb_MyUser[] SearchList(Expression<Func<tb_MyUser, bool>> where)
        {
            //Monitor.Enter(_objLock);
            tb_MyUser[] list = null;
            try
            { //将xml反序列化为linq
                using (DbContext context = GetContext())//解决缓存问题，所以new 
                {
                    list = context.Set<tb_MyUser>().Where(where).ToArray();
                }
                return list;
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-GetSearchList,类型： " + ModelHandle.GetTableName<tb_MyUser>(), e);
                return null;
            }
            finally
            {
                //Monitor.Exit(_objLock);
            }
        }
    }
}
