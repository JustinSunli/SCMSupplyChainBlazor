using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "仓库")]
    public class Depots : BasePoco
    {
        [Display(Name = "仓库名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, ErrorMessage = "仓库名称超过限制40")]
        public string DepotName { get; set; }

        [Display(Name = "联系人")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, ErrorMessage = "联系人超过限制20")]
        public string DepotMan { get; set; }

        [Display(Name = "联系电话")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^1[0-9]{10}$", ErrorMessage = "请输入正确的手机号")]
        [StringLength(20, ErrorMessage = "联系电话超过限制,20内")]
        public string DepotTelephone { get; set; }

        [Display(Name = "仓库地址")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(300, ErrorMessage = "仓库地址超过限制300")]
        public string DepotAddress { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制500")]
        public string DepotDesc { get; set; }

    }
}
