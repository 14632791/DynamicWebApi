using Metro.DynamicModeules.Interface.Service.Update;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using UpdateSystem.Web.Common;
using System.Linq;
using Metro.DynamicModeules.Models.Update;
using System;

namespace UpdateSystem.Web.Controllers
{
    [Authority]
    public class HomeController : Controller
    {
        [Dependency]
        public IUpProject PS { get; set; }
        public ActionResult Index()
        {
            tb_UpProject[] m = PS.GetSearchList(u => !string.IsNullOrEmpty(u.code));
                //(new tb_UpProject { PageSize = 10, PagedIndex = 1 }, out totalCount);
            return View("~/Views/System/Main.cshtml", m);
        }

    }
}