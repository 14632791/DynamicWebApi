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
    public class BusinessTablesController : ApiControllerBase<sys_BusinessTables>
    {
        public BusinessTablesController(BusinessTablesService service) : base(service)
        {
        }
    }
}
