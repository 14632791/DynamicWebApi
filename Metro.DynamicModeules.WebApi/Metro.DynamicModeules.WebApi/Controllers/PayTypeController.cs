using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Service;

namespace Metro.DynamicModeules.WebApi.Controllers
{
    public class PayTypeController : ApiControllerBase<tb_PayType>
    {

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
