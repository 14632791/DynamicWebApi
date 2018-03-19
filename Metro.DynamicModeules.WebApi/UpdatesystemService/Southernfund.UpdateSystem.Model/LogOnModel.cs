using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Southernfund.UpdateSystem.Model
{
    public class LogOnModel
    {
        private string _userName;
        private string _password;
        private string _code;

        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "3-20个字符内", MinimumLength = 3)]
        [Display(Name = "用户名")]
        public string UserName
        {
            set { _userName = HttpUtility.HtmlEncode(value); }
            get { return _userName; }
        }

        [StringLength(30, ErrorMessage = "6-30个字符内", MinimumLength = 6)]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password
        {
            set { _password = HttpUtility.HtmlEncode(value); }
            get { return _password; }
        }
        [Required(ErrorMessage = "验证码必填")]
        [Display(Name = "验证码")]
        public string Code
        {
            set { _code = HttpUtility.HtmlEncode(value); }
            get { return _code; }
        }

    }
}
