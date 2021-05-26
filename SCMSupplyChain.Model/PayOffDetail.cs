using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name= "报溢单详情单")]
    public class PayOffDetail:BasePoco
    {

        [Display(Name = "报溢详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过限制,200内")]
        public string PODID { get; set; }

        [Display(Name = "报溢单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid PayOffsID { get; set; }

        [Display(Name = "报溢单号")]
        public PayOffs PayOffs { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int PODAmount { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double PODPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string PODDesc { get; set; }

    }
}
