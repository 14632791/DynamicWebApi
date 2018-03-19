using Metro.DynamicModeules.Interface.Service;
using Metro.DynamicModeules.Models.Sys;
using Microsoft.Practices.Unity;
using PagedList;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using UpdateSystem.Web.Common;

namespace UpdateSystem.Web.Controllers
{

    public class UserController : Controller
    {
        [Dependency]
        public IMyUser Us { get; set; }


        [Authority]
        public ActionResult Index(int pageIndex = 1, string unameText = "")
        {
            int pgsize = 10;
            Expression<Func<tb_MyUser, bool>> where = u => !string.IsNullOrEmpty(u.Account);
            if (!string.IsNullOrEmpty(unameText))
            {
                where = u => u.Account.Contains(unameText);
            }
            int totalCount = (int)Us.GetListCount(where);

            tb_MyUser[] list = Us.GetSearchListByPage<DateTime>(where, u => u.CreateTime.Value, 10, pageIndex);
                //GetUserModels(new tb_MyUser { MerId = "", search_name = unameText, page = pageIndex, pageSize = pgsize }, out totalCount);
            if (list == null)
            {
                return View("~/Views/System/User/List.cshtml", null);
            }
            var pageList = new StaticPagedList<tb_MyUser>(list, pageIndex, pgsize, totalCount);
            return View("~/Views/System/User/List.cshtml", pageList);
        }


        public ActionResult Create(string id = "")// 0)
        {
            tb_MyUser model = new tb_MyUser();
            if (!string.IsNullOrEmpty(id))// > 0) 
                model = Us.Find(new object[] {id });//GetUserInfoById(id);
            return View("~/Views/System/User/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Save(tb_MyUser model)
        {
            //if (model.Password != model.PasswordCheck)
            //{
            //    ViewData["msg"] = "确认的密码不一致！";
            //    return View("~/Views/shared/_msg.cshtml");
            //}
            //if (ModelState.IsValid)
            //{
                if (!string.IsNullOrEmpty(model.Account))
                {
                    model.LastUpdatedBy = Session["UserName"].ToString();
                    ViewData["msg"] = Us.Update(model) ? "编辑成功！" : "编辑失败！";
                }
                else
                {
                    model.CreatedBy = Session["UserName"].ToString();

                    ViewData["msg"] =null!= Us.Add(model) ? "新增成功！" : "新增失败！";
                }
            //}
            return View("~/Views/shared/_msg.cshtml");
        }

        public ActionResult Delete(string id)
        {
            bool b = true;
            string[] ids = id.Split(',');
            foreach (var s in ids.Where(s => !Us.Delete(true,new object[] { s })))
            {
                b = false;
            }
            ViewData["msg"] = b ? "删除成功！" : "删除失败！";
            return View("~/Views/shared/_msg.cshtml");
        }



        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="editName"></param>
        /// <returns></returns>
        public JsonResult CheckUserName(string userName, string editName)
        {
            //int totalCount;
            //var list = Us.GetUserModels(new tb_MyUser() { is_validate = true, search_merId = 1, search_name = userName, page = 1, pageSize = 100 }, out totalCount);

            //如果已经存在
            if (Us.GetListCount(u=>u.Account== userName) >0 || string.IsNullOrEmpty(userName))//list.Count > 0 && userName.Trim() != editName)/
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}