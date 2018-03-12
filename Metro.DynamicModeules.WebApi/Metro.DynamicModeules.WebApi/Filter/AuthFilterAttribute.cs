using Metro.DynamicModeules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Metro.DynamicModeules.WebApi.Filter
{
    public class AuthFilterAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 匿名可访问
        /// </summary>
        public bool AllowAnonymous { get; set; }

        /// <summary>
        /// 登录用户就可以访问
        /// </summary>
        public bool OnlyLogin { get; set; }

        /// <summary>
        /// 使用的资源权限名，比如多个接口可以使用同一个资源的权限，默认是/ControllerName/ActionName
        /// </summary>
        public string PowerName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var hasPower = true; //可以根据 user和url等信息判断是否有权限
            //if (!hasPower)
            //{
            //    filterContext.Result = new ApiResult
            //    {
            //        ResultData = new ResultObject { Code = -2, Msg = "无权限" },
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //    };
            //}
            return base.AuthorizeCore(httpContext);
        }
    
    }
}