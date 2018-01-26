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
    public class SysBusinessTablesController : ApiControllerBase<sys_BusinessTables>
    {
        protected override ServiceBase<sys_BusinessTables> GetService()
        {
            return new BusinessTablesService();
        }
    }
}
