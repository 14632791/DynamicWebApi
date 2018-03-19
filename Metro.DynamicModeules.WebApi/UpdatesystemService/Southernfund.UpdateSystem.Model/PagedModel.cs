using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southernfund.UpdateSystem.Model
{
    public class PagedModel
    {
        /// <summary>
        /// 列表每页数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PagedIndex { get; set; }

    }
}
