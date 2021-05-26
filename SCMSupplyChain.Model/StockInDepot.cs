﻿using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "采购入库")]
    public class StockInDepot : BasePoco
    {
        [Display(Name = "采购入库单号")]
        [Required(ErrorMessage = "采购入库单号不能为空")]
        [StringLength(200, ErrorMessage = "采购入库单号超过最长限制,200内")]
        public string SIDID { get; set; }

        [Display(Name = "供货商")]
        public Guid? ProductLendID { get; set; }
        [Display(Name = "供货商")]
        public ProductLend ProductLend { get; set; }

        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "仓库")]
        public Depots Depots { get; set; }

        [Display(Name = "采购单号")]
        public Guid? StocksID { get; set; }
        [Display(Name = "采购单号")]
        public Stocks Stocks { get; set; }

        [Display(Name = "收货时间")]
        [Required(ErrorMessage = "收货时间不能为空")]
        public DateTime? SIDDate { get; set; }

        [Display(Name = "送货单号")]
        [Required(ErrorMessage = "送货单号不能为空")]
        [StringLength(200, ErrorMessage = "送货单号超过最长限制,200内")]
        public string SIDDeliver { get; set; }

        [Display(Name = "运费")]
        [Required(ErrorMessage = "运费不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的运费")]
        public double SIDFreight { get; set; }

        [Display(Name ="审核状态")]
        public SIDData SIDData { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制500")]
        public string SIDDesc { get; set; }

    }
}
