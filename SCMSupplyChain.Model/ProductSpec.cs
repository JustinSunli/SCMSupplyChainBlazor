using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "商品规格")]
    public class ProductSpec : PersistPoco
    {
        [Display(Name = "颜色")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过最长限制,200内")]
        public string PSName { get; set; }
    }
}
