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
    public class MyUserController : ApiControllerBase<tb_MyUser>
    { 
        protected override ServiceBase<tb_MyUser> GetService()
        {
            return new MyUserService();
        }
    }
}