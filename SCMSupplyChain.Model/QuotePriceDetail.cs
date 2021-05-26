using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "报价单详单")]
    public class QuotePriceDetail : BasePoco
    {
        [Display(Name = "报价详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过限制,200内")]
        public string QPDID { get; set; }

        [Display(Name = "报价单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? QuotePriceID { get; set; }

        [Display(Name = "报价单号")]
        public QuotePrice QuotePrice { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int QPDAmount { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double QPDPrice { get; set; }

        [Display(Name ="折扣")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double QPDDiscont { get; set; }
       
        [Display(Name = "折后价")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double QPDDisPrice { get; set; }

        [Display(Name ="备注")]
        [StringLength(500,ErrorMessage="备注超过最长限制,500内")]
        public string QPDDesc { get; set; }
    }
}
