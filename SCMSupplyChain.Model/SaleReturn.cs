﻿using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "销售退货单")]
    public class SaleReturn: PersistPoco
    {
        [Display(Name = "销售退货单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超最长限制,100内")]
        public string SRID { get; set; } = "SR" + DateTime.Now.ToString("yyyyMMddhhmmss");

        [Display(Name ="客户")]
        [Required(ErrorMessage= "{0}不能为空")]
        public Guid? CustomersID { get; set; }

        [Display(Name = "客户")]
        public Customers Customers { get; set; }

        [Display(Name ="仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? DepotsID { get; set; }

        [Display(Name = "仓库")]
        public Depots Depots { get; set; }

        [Display(Name ="状态")]
        public SRState SRState { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string SRDesc { get; set; }
    }
}
