using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Southernfund.UpdateSystem.Model
{
    public class RoleModel
    {
        /// <summary>
        /// 角色表ID
        /// </summary>
        public int RlId { get; set; }

        /// <summary>
        /// 商家表ID
        /// </summary>
        public int? MerId { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(10, ErrorMessage = "输入的范围在2-10个字符以内！", MinimumLength = 2)]
        [Display(Name = "角色名称")]
        [Remote("CheckRoleName", "Role", AdditionalFields = "EditName", ErrorMessage = "此角色名称已存在！")]
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; }

        //////////////////////查询////////////////
        /// <summary>
        ///  商家ID
        /// </summary>
        public int? search_merId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string search_name { get; set; }
        /// <summary>
        /// 是否用于重复验证
        /// </summary>
        public bool is_validate { get; set; }
        /// <summary>
        /// 列表分页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 列表分页大小
        /// </summary>
        public int pageSize { get; set; }
    }
}
