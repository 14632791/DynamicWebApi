using System;
using System.IO;
using System.Web.Configuration;
using log4net.Config;

namespace Southernfund.Web
{
    public class Log4NetConfig
    {
        public static void RegisterLog4Net()
        {
            //初始化日志文件 
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + WebConfigurationManager.AppSettings["log4net"];
            var fi = new FileInfo(path);
            XmlConfigurator.Configure(fi);
        }
    }
}