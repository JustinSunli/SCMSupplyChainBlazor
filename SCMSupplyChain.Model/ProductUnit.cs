using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "商品单位")]
    public class ProductUnit: PersistPoco
    {
        [Display(Name = "单位名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过最长限制,200内")]
        public string PUName { get; set; }
    }
}
