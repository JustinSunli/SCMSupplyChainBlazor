using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;


namespace SCMSupplyChain.Model
{
    [Display(Name = " 其它入库详情单")]
    public class OtherInDepotDetail : BasePoco
    {
        [Display(Name = "其它入库详情单号")]
        [Required(ErrorMessage = "其它入库详情单号不能为空")]
        [StringLength(200, ErrorMessage = "其它入库详情单号超过限制,200内")]
        public string OIDDID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Products Products { get; set; }

        [Display(Name = "其它入库单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid OtherInDepotID { get; set; }

        [Display(Name = "其它入库单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public OtherInDepot OtherInDepot { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage="数量不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int OIDDAmount { get; set; }

        [Display(Name ="价格")]
        [Required(ErrorMessage = "价格不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double OIDDPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string OIDDDesc { get; set; }

    }
}
