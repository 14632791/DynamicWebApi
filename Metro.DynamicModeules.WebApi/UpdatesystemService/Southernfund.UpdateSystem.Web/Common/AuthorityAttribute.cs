using System;
using System.Web.Mvc;

namespace UpdateSystem.Web.Common
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorityAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 在执行操作方法之前由 ASP.NET MVC 框架调用。
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["UserName"] == null)
            {
                //RedirectToLogin(filterContext);
                filterContext.Result = new RedirectResult("~/Login/LogIn?state=0");
            }
        }
    }
}