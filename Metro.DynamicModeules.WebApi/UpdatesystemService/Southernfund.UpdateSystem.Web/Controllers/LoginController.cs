using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Southernfund.UpdateSystem.Model.Util;
using Southernfund.UpdateSystem.Model;
using Microsoft.Practices.Unity;
using Southernfund.UpdateSystem.IService;
using Southernfund.UpdateSystem.Service;

namespace Southernfund.UpdateSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        [Dependency]
        public IUserService Us { get; set; }
        [Dependency]
        public IUpdate US { get; set; }

        #region 登录处理

        public ActionResult test()
        {
            return View();
        }

        //
        // GET: /Login/
        public ActionResult LogIn(int state = 0)
        {
            if (state == 1)
                ModelState.AddModelError("Code", "对不起，您没有权限或连接超时！");
            return View("~/Views/LogOn.cshtml");
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LogOn(LogOnModel user)
        {
            try
            {
                //if (Session["ValidateCode"] == null || Session["ValidateCode"].ToString().ToLower() != user.Code.ToLower())
                //{
                //    ModelState.AddModelError("code", "验证码输入不正确！");
                //    return View("~/Views/LogOn.cshtml", user);
                //}
                //if (!ModelState.IsValid) return View("~/Views/LogOn.cshtml", user);
                user.Password = Md5Manger.Md5Encrypt(user.Password);
                var t = Us.ValidateUser(user.UserName, user.Password);
                if (t != null)
                {
                    Session["MerId"] = t.MerId;
                    Session["UserName"] = t.UserName;
                    // 在新会话启动时运行的代码 ,设置一个月不失效
                    Session.Timeout =60*24;
                    //if (t.IsDisabled == 1)
                    //{
                    return RedirectToAction("Index", "Home");
                    //}
                    //ModelState.AddModelError("Code", "该用户已被禁用，请联系系统管理员！");
                }
                else
                {
                    ModelState.AddModelError("Code", "账号或密码错误！");
                }
                return View("~/Views/LogOn.cshtml", user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Code", ex.Message);
                return View("~/Views/LogOn.cshtml", user);
            }
        }
        #endregion

        #region 退出登录
        public ActionResult LogOut(string url = "")
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Session.Abandon();
            Session.Clear();

            Response.Cookies.Clear();
            Request.Cookies.Clear();

            if (!string.IsNullOrEmpty(url))
                return Redirect(url);
            return View("~/Views/LogOn.cshtml");
        }
        #endregion
    }
}