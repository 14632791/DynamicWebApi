using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southernfund.UpdateSystem.Model
{
    public class UpdateModel : PagedModel
    {
        public string ID { get; set; }
        public string ProjectsID { get; set; }
        [Required(ErrorMessage = "必填项")]
        public string Version { get; set; }
        public Nullable<bool> Mandatory { get; set; }
        public string getBoolText { get { return (bool)Mandatory ? "是" : "否"; } }
        public string DownloadURL { get; set; }

        public string ServerUrl { get; set; }
        
        public string Remark { get; set; }

        /// <summary>
        /// 0 = XPx86...参考UpdateType
        /// </summary>
        public Nullable<int> Type { get; set; }
        public string UpdateLog { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }

    }

    /// <summary>
    /// 更新的客户端类型
    /// </summary>
    public enum UpdateType
    {
        XPx86 = 0,
        XPx64,
        Win7x86,
        Win7x64
    }
}
