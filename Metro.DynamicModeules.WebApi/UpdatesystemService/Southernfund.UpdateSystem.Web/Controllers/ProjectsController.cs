using Microsoft.Practices.Unity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Southernfund.UpdateSystem.IService;
using Southernfund.UpdateSystem.Model;
using Southernfund.UpdateSystem.Web.Common;

namespace Southernfund.UpdateSystem.Web.Controllers
{
    [Authority]
    public class ProjectsController : Controller
    {
        [Dependency]
        public IProjects PSer { get; set; }

        public ActionResult Index(int pageIndex = 1, string Name = "")
        {
            int pageSize = 10;
            int totalCount;

            var list = PSer.GetList(new ProjectsModel { Name = Name, PagedIndex = pageIndex, PageSize = pageSize }, out totalCount);
            if (list != null)
            {
                var pageList = new StaticPagedList<ProjectsModel>(list, pageIndex, pageSize, totalCount);
                return View(pageList);
            }
            return View();
        }

        public ActionResult COE(string id ="")// 0)
        {
            ProjectsModel m = new ProjectsModel();
            if (!string.IsNullOrEmpty(id))// > 0)
            {
                m = PSer.GetModel(id);
            }
            return View(m);
        }

        //
        // POST: /Projects/Create
        [HttpPost]
        public ActionResult Save(ProjectsModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(form.ID))// > 0)
                    {
                        ViewData["msg"] = PSer.Update(form) ? "修改成功！" : "修改失败！";
                    }
                    else
                    {
                        ViewData["msg"] = PSer.Add(form) ? "新增成功！" : "新增失败！";
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
                ViewData["msg"] = PSer.Delete(id) ? "删除成功！" : "删除失败！";
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
