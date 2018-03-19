using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Southernfund.UpdateSystem.Model
{
    public class UserModel
    {
        /// <summary>
        /// 用户表ID
        /// </summary>
        public string UsId { get; set; }

        /// <summary>
        /// 商家表ID
        /// </summary>
        public string MerId { get; set; }


        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "输入的范围在2-20个字符以内！", MinimumLength = 2)]
        [Display(Name = "姓名")]
        [Remote("CheckUserName", "User", AdditionalFields = "EditName", ErrorMessage = "此用户名已存在！")]
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        public string PasswordCheck { get; set; }
        
        /// <summary>
        /// 性别(0:男，1:女)
        /// </summary>
        public int Sex { get; set; }
        public string SexText { get { return Sex == 0 ? "男" : "女"; } }
        /// <summary>
        /// 部门(1:经营部，2:管理部，3:财务部)
        /// </summary>
        public int Department { get; set; }


        /// <summary>
        /// 员工类型(1:经理，2:普通员工，3:管理人员，4:财务人员，5:老板)
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// 是否禁用(0:是，1:否)
        /// </summary>
        public bool IsDisabled { get; set; }
        public string IsDisabledText { get{return IsDisabled ?"是" :"否";} }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }


        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

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

        /// <summary>
        /// 员工类型
        /// </summary>
        public static List<SelectListItem> TypeEnum = new List<SelectListItem>(){  
            new SelectListItem(){ Value = "1",Text = "经理" },  
            new SelectListItem(){ Value = "2",Text = "普通员工" },  
            new SelectListItem(){ Value = "3",Text = "管理人员" },  
            new SelectListItem(){ Value = "4",Text = "财务人员" },  
            new SelectListItem(){ Value = "5",Text = "老板" }
        };

        /// <summary>
        /// 部门
        /// </summary>
        public static List<SelectListItem> DepartmentEnum = new List<SelectListItem>(){  
            new SelectListItem(){ Value = "1",Text = "经营部" },  
            new SelectListItem(){ Value = "2",Text = "管理部" },  
            new SelectListItem(){ Value = "3",Text = "财务部" }
        };

        ///////////////////查询//////////////////
        /// <summary>
        ///  商家ID
        /// </summary>
        public int? search_merId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string search_number { get; set; }
        /// <summary>
        /// 用户名
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

        public string RealName { get; set; }
        public string Remark { get; set; }
      
    }
}
