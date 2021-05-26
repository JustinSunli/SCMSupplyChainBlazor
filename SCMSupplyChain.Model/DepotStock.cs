using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name ="库存")]
    public class DepotStock: PersistPoco
    {
        [Display(Name = "仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid DepotsID { get; set; }

        [Display(Name = "仓库")]
        public Depots Depots { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "库存数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int DSAmount { get; set; }

        [Display(Name = "进价")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        [Required(ErrorMessage = "进价不允许为空")]
        public double DSPrice { get; set; }

    }
}
