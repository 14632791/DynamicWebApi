using Metro.DynamicModeules.Interface.Service.Update;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using UpdateSystem.Web.Common;
using System.Linq;

namespace UpdateSystem.Web.Controllers
{
    [Authority]
    public class HomeController : Controller
    {
        [Dependency]
        public IUpProject PS { get; set; }
        public ActionResult Index()
        {
            int totalCount;
            var m = PS.GetSearchListByPage(new ProjectsModel { PageSize = 10, PagedIndex = 1 }, out totalCount);
            return View("~/Views/System/Main.cshtml", m);
        }

    }
}