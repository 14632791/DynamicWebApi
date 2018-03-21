using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Service;
using System.Xml.Linq;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using System.Linq.Expressions;

namespace Metro.DynamicModeules.WebApi.Controllers
{
    public class PayTypeController : ApiControllerBase<tb_PayType>
    {
        public override tb_PayType[] GetSearchListByPage(XElement xmlPredicate, int pageSize, int pageIndex)
        {
            Expression<Func<tb_PayType, bool>> where = SerializeHelper.DeserializeExpression<tb_PayType, bool>(xmlPredicate);
            return _service.GetSearchListByPage(where, g => g.isid, pageSize, pageIndex);
        }

        public void PostAll([FromBody]string value)
        {
            var model = _service.Find(new object[] { "CASH" });
        }

        protected override ServiceBase<tb_PayType> GetService()
        {
            return new PayTypeService();
        }
    }
}
