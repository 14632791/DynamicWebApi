using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UpdateSystem.Web.Common
{
    public enum XmlFileType
    {
        DBScriptDataItem,
        UpdateInfo
    }
    public class XMLPath
    {
        public static string GetXmlPath(XmlFileType type)
        {
            if (type == XmlFileType.DBScriptDataItem)
            {
                return HttpRuntime.AppDomainAppPath + ConfigurationManager.AppSettings["DBScriptDataItem"];
            }
            else if (type == XmlFileType.UpdateInfo)
            {
                return HttpRuntime.AppDomainAppPath + ConfigurationManager.AppSettings["UpdateInfo"];
            }
            return "";
        }
    }
}