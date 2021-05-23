using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name= "报溢单详情单")]
    public class PayOffDetail:BasePoco
    {

        [Display(Name = "报溢详情单号")]
        [Required(ErrorMessage = "报溢详情单号不能为空")]
        [StringLength(200, ErrorMessage = "报溢详情单号超过限制,200内")]
        public string PODID { get; set; }

        [Display(Name = "报溢单号")]
        public Guid? PayOffsID { get; set; }
        [Display(Name = "报溢单号")]
        public PayOffs PayOffs { get; set; }

        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "数量不能为空")]
        public int PODAmount { get; set; }

        [Display(Name = "价格")]
        public double PODPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string PODDesc { get; set; }

    }
}
