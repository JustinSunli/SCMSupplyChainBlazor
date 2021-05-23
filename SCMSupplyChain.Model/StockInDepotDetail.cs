using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "采购入库详情单")]
    public class StockInDepotDetail: BasePoco
    {

        [Display(Name = "采购入库单详情单号")]
        [Required(ErrorMessage = "采购入库单详情单号不能为空")]
        [StringLength(100, ErrorMessage = "采购入库单详情单号超过限制100")]
        public string SIDDID { get; set; }

        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "采购入库单号")]
        public Guid? StockInDepotID { get; set; }
        [Display(Name = "采购入库单号")]
        public StockInDepot StockInDepot { get; set; }

        [Display(Name ="数量")]
        public int SIDDAmount { get; set; }

        [Display(Name = "价格")]
        public int SIDDPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string SIDDDesc { get; set; }
    }
}
