using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name ="库存")]
    public class DepotStock: PersistPoco
    {
        [Display(Name = "仓库")]
        [Required(ErrorMessage = "仓库不允许为空")]
        public Guid DepotsID { get; set; }
        [Required(ErrorMessage = "仓库不允许为空")]
        public Depots Depots { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "商品不允许为空")]
        public Guid ProductsID { get; set; }
        [Display(Name = "商品")]
        [Required(ErrorMessage = "商品不允许为空")]
        public Products Products { get; set; }

        [Display(Name = "库存数量")]
        [Required(ErrorMessage= "库存数量不允许为空")]
        public int DSAmount { get; set; }

        [Display(Name = "进价")]
        [Required(ErrorMessage = "进价不允许为空")]
        public double DSPrice { get; set; }

    }
}
