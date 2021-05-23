using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;


namespace SCMSupplyChain.Model
{
    [Display(Name = "销售退货详情")]
    public class SaleReturnDetail : PersistPoco
    {
        [Display(Name = "销售退货详情单号")]
        [Required(ErrorMessage = "销售退货详情单号不能为空")]
        [StringLength(100, ErrorMessage = "销售退货详情单号超最长限制,100内")]
        public string SRDID { get; set; }

        [Display(Name = "销售退货单号")]
        [Required(ErrorMessage= "销售退货单号不能为空")]
        public Guid SaleReturnID { get; set; }

        [Display(Name = "销售退货单号")]
        [Required(ErrorMessage = "销售退货单号不能为空")]
        public SaleReturn SaleReturn { get; set; }

        [Display(Name ="商品")]
        [Required(ErrorMessage="商品不能为空")]
        public Guid ProductsID { get; set; }
        [Display(Name = "商品")]
        [Required(ErrorMessage = "商品不能为空")]
        public Products Products { get; set; }

        [Display(Name ="数量")]
        [Required(ErrorMessage = "数量不能为空")]
        public int SRDAmount { get; set; }

        [Display(Name ="售价")]
        [Required(ErrorMessage = "售价不能为空")]
        public double SRDPrice { get; set; }


        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string SRDDesc { get; set; }
    }
}
