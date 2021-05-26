using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "报价单详单")]
    public class QuotePriceDetail : BasePoco
    {
        [Display(Name = "报价详情单号")]
        [Required(ErrorMessage = "报价详情单号不能为空")]
        [StringLength(200, ErrorMessage = "报价详情单号超过限制,200内")]
        public string QPDID { get; set; }

        [Display(Name = "报价单号")]
        public Guid? QuotePriceID { get; set; }
        [Display(Name = "报价单号")]
        public QuotePrice QuotePrice { get; set; }

        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "数量不能为空")]
        public int QPDAmount { get; set; }

        [Display(Name = "价格")]
        public double QPDPrice { get; set; }

        [Display(Name ="折扣")]
        public double QPDDiscont { get; set; }
       
        [Display(Name = "折后价")]
        public double QPDDisPrice { get; set; }

        [Display(Name ="备注")]
        [StringLength(500,ErrorMessage="备注超过最长限制,500内")]
        public string QPDDesc { get; set; }
    }
}
