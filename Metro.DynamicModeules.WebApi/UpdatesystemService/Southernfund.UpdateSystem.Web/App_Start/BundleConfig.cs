using System.Web;
using System.Web.Optimization;

namespace UpdateSystem.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/system_css/common/common.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //引用js时，尽量用‘-’替代‘.’，不然服务器端会不识别多个‘.’的情况
            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                 "~/Scripts/jquery-{version}.js",
                          "~/Scripts/easyui/jquery.easyui.min.js",
                          "~/Scripts/easyui/locale/easyui-lang-zh_CN.js",
                          "~/Scripts/easyui/extension/easyui.public.js",
                           "~/Scripts/easyui/extension/easyui.menu.js"
                          ));

            bundles.Add(new ScriptBundle("~/pages/list").Include(
                      "~/Scripts/jquery-{version}.js",
                         "~/Scripts/easyui/extension/easyui.business.js"
                       ));//引用当前项目js库


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/bundles/easyuicss").Include(
                       "~/Scripts/easyui/themes/default/easyui.css",
                        "~/Scripts/easyui/themes/icon.css"

                       ));
        }
    }
}
