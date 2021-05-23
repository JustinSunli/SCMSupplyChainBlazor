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
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "其它入库单号")]
        public Guid? OtherInDepotID { get; set; }
        [Display(Name = "其它入库单号")]
        public OtherInDepot OtherInDepot { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage="数量不能为空")]
        public int OIDDAmount { get; set; }

        [Display(Name ="价格")]
        [Required(ErrorMessage = "价格不能为空")]
        public double OIDDPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string OIDDDesc { get; set; }

    }
}
