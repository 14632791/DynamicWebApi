using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Service;
using System.Web.Http;
using System.Xml.Linq;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using System.Linq.Expressions;

namespace Metro.DynamicModeules.WebApi.Controllers.Sys
{
    public class AuthorityItemController : ApiControllerBase<tb_MyAuthorityItem>
    {
        protected override ServiceBase<tb_MyAuthorityItem> GetService()
        {
            _itemsService = new AuthorityItemService();
            return _itemsService;
        }

        AuthorityItemService _itemsService;

        [System.Web.Http.HttpPost]
        public IEnumerable<tb_MyAuthorityItem> GetAuthorityItems([FromBody]int menuId)
        {
            return _itemsService.GetAuthorityItems(menuId);
        }

        [System.Web.Http.HttpPost]
        public IEnumerable<tb_MyAuthorityByItem> GetAllItems()
        {
            return _itemsService.GetAllItems();
        }

        //public override tb_MyAuthorityItem[] GetSearchListByPage(XElement xmlPredicate, int pageSize, int pageIndex)
        //{
        //    Expression<Func<tb_MyAuthorityItem, bool>> where = SerializeHelper.DeserializeExpression<tb_MyAuthorityItem, bool>(xmlPredicate);
        //    return _service.GetSearchListByPage(where, g => g.Code, pageSize, pageIndex);
        //}

        protected override dynamic GetOrderBy()
        {
            Expression<Func<tb_MyAuthorityItem, string>> orderBy = g => g.Code;
            return orderBy;
        }
    }
}