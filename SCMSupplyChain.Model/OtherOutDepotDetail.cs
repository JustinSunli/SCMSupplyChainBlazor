using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "其它入库详情单")]
    public class OtherOutDepotDetail : PersistPoco
    {
        [Display(Name = "其他出库单号")]
        [Required(ErrorMessage = "其他出库单号不能为空")]
        [StringLength(200, ErrorMessage = "其他出库单号超过最长限制,200内")]
        public string OODDID { get; set; }

        [Display(Name = "其他出库单号")]
        public Guid? OtherOutDepotID { get; set; }
        [Display(Name = "其他出库单号")]
        public OtherOutDepot OtherOutDepot { get; set; }

        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "数量不能为空")]
        public int OODDAmount { get; set; }

        [Display(Name = "售价")]
        [Required(ErrorMessage = "售价不能为空")]
        public double OODDPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string OODDDesc { get; set; }

    }
}
