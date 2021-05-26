using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "出入库记录详情")]
    public class InOutDepotDetail: PersistPoco
    {
        [Display(Name = " 出入库记录单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? InOutDepotID { get; set; }

        [Display(Name = " 出入库记录单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public InOutDepot InOutDepot { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Products Products { get; set; }

        [Display(Name ="数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int IODDAmount { get; set; }

        [Display(Name ="价格")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double IODDPrice { get; set; }
    }
}
