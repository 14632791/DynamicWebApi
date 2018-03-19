using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southernfund.UpdateSystem.Model
{
    public class ProjectsModel : PagedModel
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "必填")]
        public string Name { get; set; }
        public int Type { get; set; }
        [Required(ErrorMessage = "必填")]

        public string Code { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public bool Disable { get; set; }
        public string DownloadServerURL { get; set; }

    }
}
