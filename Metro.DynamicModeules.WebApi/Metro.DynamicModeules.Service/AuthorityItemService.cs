using Metro.DynamicModeules.Models.Sys;
using Metro.DynamicModeules.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.Service
{
    public class AuthorityItemService : ServiceBase<tb_MyAuthorityItem>
    {
        /// <summary>
        /// 获取该窗体对应的所有按钮
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public IEnumerable<tb_MyAuthorityItem> GetAuthorityItems(int menuId)
        {
            NormalEntity normalContext = (NormalEntity)DbContext;
            try
            {
                var items = from a in normalContext.tb_MyAuthorityItem
                            where (from i in normalContext.tb_MyAuthorityByItem
                                   where i.MenuId.Equals(menuId)
                                   select i.AuthorityCode).
                            Distinct().Contains(a.Code)
                            select a;
                return items.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //normalContext.Dispose();
            }
        }

        /// <summary>
        /// 获取所有中间表的内容
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tb_MyAuthorityByItem> GetAllItems()
        {
            NormalEntity normalContext = (NormalEntity)DbContext;
            try
            {
               return normalContext.tb_MyAuthorityByItem.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
