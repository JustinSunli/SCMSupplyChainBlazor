using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;


namespace SCMSupplyChain.Model
{
    [Display(Name = "销售退货详情")]
    public class SaleReturnDetail : PersistPoco
    {
        [Display(Name = "销售退货详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超最长限制,100内")]
        public string SRDID { get; set; }

        [Display(Name = "销售退货单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? SaleReturnID { get; set; }

        [Display(Name = "销售退货单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public SaleReturn SaleReturn { get; set; }

        [Display(Name ="商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? ProductsID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Products Products { get; set; }

        [Display(Name ="数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int SRDAmount { get; set; }

        [Display(Name ="售价")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double SRDPrice { get; set; }


        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string SRDDesc { get; set; }
    }
}
