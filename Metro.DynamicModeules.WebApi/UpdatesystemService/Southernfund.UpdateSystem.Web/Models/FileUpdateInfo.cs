using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Southernfund.UpdateSystem.Web.Models
{
    public class UpdateInfo
    {
        public bool NeedUpdate { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string FileDownloadURL { get; set; }
        public string XmlDownloadURL { get; set; }

        /// <summary>
        /// 下载的部分URL
        /// </summary>
        public string FileDownloadPartURL { get; set; }

        /// <summary>
        /// 下载XML的部分URL
        /// </summary>
        public string XmlDownloadPartURL { get; set; }
        public bool Mandatory { get; set; }

    }
}