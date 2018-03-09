using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metro.DynamicModeules.WebApi.Controllers.Sys
{
    public class ModulesController : ApiControllerBase<sys_Modules>
    {
        public override sys_Modules Find(object[] keyValues)
        {
            var module = base.Find(keyValues);
            return module;
        }
    }
}