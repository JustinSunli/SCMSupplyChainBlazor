using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "采购详情单")]
    public class StockDetail : PersistPoco
    {
        [Display(Name = "采购详情单号")]
        [Required(ErrorMessage = "采购详情单号不能为空")]
        [StringLength(100, ErrorMessage = "采购详情单号超最长限制,100内")]
        public string SDetailID { get; set; }

        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "采购单号")]
        public Guid? StocksID { get; set; }
        [Display(Name = "采购单号")]
        public Stocks Stocks { get; set; }

        [Display(Name = "数量")]
        public int SDetailAmount { get; set; }

        [Display(Name = "价格")]
        public double SDetailPrice { get; set; }

        [Display(Name ="入库数量")]
        public int SDetailDepAmount { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string SDetailDesc { get; set; }
    }
}
