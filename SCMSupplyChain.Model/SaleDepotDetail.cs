using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "销售出库详情")]
    public class SaleDepotDetail: PersistPoco
    {

        [Display(Name = "销售出库详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超最长限制,100内")]
        public string SDDID { get; set; }

        [Display(Name = "销售出库单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid SaleDepotID { get; set; }

        [Display(Name = "销售出库单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public SaleDepot SaleDepot { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int SDDAmount { get; set; }

        [Display(Name = "售价")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double SDDPrice { get; set; }

        [Display(Name = "折扣")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double SDDDiscount { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string SDDDesc { get; set; }

    }
}
