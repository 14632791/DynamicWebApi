using Microsoft.Practices.Unity;
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
    public class HomeController : Controller
    {
        [Dependency]
        public IProjects PS { get; set; }
        public ActionResult Index()
        {
            int totalCount;
            var m = PS.GetList(new ProjectsModel { PageSize = 10, PagedIndex = 1 }, out totalCount);
            return View("~/Views/System/Main.cshtml", m);
        }

    }
}