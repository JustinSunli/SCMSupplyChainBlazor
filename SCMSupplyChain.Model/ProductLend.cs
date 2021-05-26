using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name="供货商")]
    public class ProductLend: BasePoco
    {
        [Display(Name ="供货商名称")]
        [Required(ErrorMessage= "供货商名称不嫩为空")]
        [StringLength(100,ErrorMessage= "供货商名称超过最长限制,100内")]
        public string PPName { get; set; }

        [Display(Name = "公司名称")]
        [Required(ErrorMessage = "公司名称不嫩为空")]
        [StringLength(100, ErrorMessage = "公司名称超过最长限制,100内")]
        public string PPCompany { get; set; }

        [Display(Name ="联系人")]
        [Required(ErrorMessage="联系人不能为空")]
        [StringLength(100,ErrorMessage= "联系人超过最长限制,100内")]
        public string PPMan { get; set; }

        [Display(Name ="联系电话")]
        [Required(ErrorMessage= "联系电话不能为空")]
        [RegularExpression(@"^1[0-9]{10}$", ErrorMessage = "请输入正确的手机号")]
        [StringLength(20, ErrorMessage = "联系电话最长限制,20内")]
        public string PPTel { get; set; }

        [Display(Name = "地址")]
        [Required(ErrorMessage = "地址不能为空")]
        [StringLength(300, ErrorMessage = "地址超过限制,300内")]
        public string PPAddress { get; set; }

        [Display(Name = "传真")]
        [StringLength(200, ErrorMessage = "传真超过限制,200内")]
        public string PPFax { get; set; }

        [Display(Name ="邮箱")]
        [RegularExpression(@"^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "请输入正确的邮箱")]
        public string Email { get; set; }

        [Display(Name ="网址")]
        [StringLength(200, ErrorMessage = "网址超过限制,200内")]
        public string PPUrl { get; set; }

        [Display(Name = "银行名称")]
        [Required(ErrorMessage = "银行名称不能为空")]
        [StringLength(200, ErrorMessage = "银行名称超过限制,200内")]
        public string PPBank { get; set; }


        [Display(Name = "银行账号")]
        [Required(ErrorMessage= "银行账号不能为空")]
        [StringLength(200, ErrorMessage = "银行账号超过限制,200内")]
        public string PPGoods { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制500")]
        public string PPDesc { get; set; }
    }
}
