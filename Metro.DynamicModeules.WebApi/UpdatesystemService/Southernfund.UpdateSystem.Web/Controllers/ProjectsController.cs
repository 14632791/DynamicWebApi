using Metro.DynamicModeules.Interface.Service.Update;
using Metro.DynamicModeules.Models.Update;
using Microsoft.Practices.Unity;
using PagedList;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using UpdateSystem.Web.Common;

namespace UpdateSystem.Web.Controllers
{
    [Authority]
    public class ProjectsController : Controller
    {
        [Dependency]
        public IUpProject PSer { get; set; }

        public ActionResult Index(int pageIndex = 1, string Name = "")
        {
            int pageSize = 10;
            Expression<Func<tb_UpProject, bool>> where = u => !string.IsNullOrEmpty(u.name);
            if (!string.IsNullOrEmpty(Name))
            {
                where = u => u.name.Contains(Name);
            }
            int totalCount = (int)PSer.GetListCount(where);
            tb_UpProject[] list = PSer.GetSearchListByPage<string>(where, u => u.code, 10, pageIndex);
            //GetList(new tb_UpProject { Name = Name, PagedIndex = pageIndex, PageSize = pageSize }, out totalCount);
            if (list != null)
            {
                var pageList = new StaticPagedList<tb_UpProject>(list, pageIndex, pageSize, totalCount);
                return View(pageList);
            }
            return View();
        }

        public ActionResult COE(string id ="")// 0)
        {
            tb_UpProject m = new tb_UpProject();
            if (!string.IsNullOrEmpty(id))// > 0)
            {
                m = PSer.Find(new object[] { id });//GetModel(id);
            }
            return View(m);
        }

        //
        // POST: /Projects/Create
        [HttpPost]
        public ActionResult Save(tb_UpProject form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(form.code))// > 0)
                    {
                        ViewData["msg"] = PSer.Update(form) ? "修改成功！" : "修改失败！";
                    }
                    else
                    {
                        ViewData["msg"] =null!=PSer.Add(form) ? "新增成功！" : "新增失败！";
                    }
                }
            }
            catch { }
            return View("~/Views/shared/_msg.cshtml");
        }

        //
        //// POST: /Projects/Delete/5
        //[HttpPost, HttpGet]
        public ActionResult Delete(string id ="")// 0)
        {
            try
            {
                ViewData["msg"] = PSer.Delete(true,new object[] { id }) ? "删除成功！" : "删除失败！";
                return View("~/Views/shared/_msg.cshtml");
            }
            catch
            {
                ViewData["msg"] = "删除异常";
                return View("~/Views/shared/_msg.cshtml");
            }
        }
    }
}
