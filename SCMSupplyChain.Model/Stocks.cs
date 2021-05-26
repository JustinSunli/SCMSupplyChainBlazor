using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "采购单")]
    public class Stocks: PersistPoco
    {
        [Display(Name = "采购单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超过限制100")]
        public string StockID { get; set; }

        [Display(Name = "供货商")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? ProductLendID { get; set; }

        [Display(Name = "供货商")]
        [Required(ErrorMessage = "{0}不能为空")]
        public ProductLend ProductLend { get; set; }

        [Display(Name ="预计交货时间")]
        public DateTime? StockInDate { get; set; }

        [Display(Name ="审核状态")]
        public StockState StockState { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string StockDesc { get; set; }
    }
}
