using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "客户表")]
    public class Customers : BasePoco
    {
        [Display(Name = "客户名称")]
        [Required(ErrorMessage = "客户名称不能为空")]
        [StringLength(200, ErrorMessage = "客户名称超过限制,200内")]
        public string CusName { get; set; }

        [Display(Name ="客户等级")]
        public CusGrade CusGrade { get; set; }

        [Display(Name ="公司名称")]
        [Required(ErrorMessage = "公司名称不能为空")]
        [StringLength(200, ErrorMessage = "公司名称超过限制,200内")]
        public string CusCompany { get; set; }

        [Display(Name ="联系人")]
        [Required(ErrorMessage = "联系人不能为空")]
        [StringLength(200, ErrorMessage = "联系人超过限制,200内")]
        public string CusMan { get; set; }

        [Display(Name = "联系电话")]
        [Required(ErrorMessage = "联系电话不能为空")]
        [RegularExpression(@"^1[0-9]{10}$", ErrorMessage = "请输入正确的手机号")]
        [StringLength(20, ErrorMessage = "联系电话最长限制,20内")]
        public string CusTelephone { get; set; }

        [Display(Name ="备注")]
        [StringLength(500,ErrorMessage ="备注超过限制,500内")]
        public string CusDesc { get; set; }
    }
}
