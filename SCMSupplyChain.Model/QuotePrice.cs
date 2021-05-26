using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{

    [Display(Name = "报价单")]
    public class QuotePrice : BasePoco
    {
        [Display(Name = "报价单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超过限制100")]
        public string QPID { get; set; }

        [Display(Name = "客户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid CustomersID { get; set; }

        [Display(Name = "客户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Customers Customers { get; set; }

        [Display(Name = "状态")]
        public QPState QPState { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制500")]
        public string QPDesc { get; set; }
    }
}
