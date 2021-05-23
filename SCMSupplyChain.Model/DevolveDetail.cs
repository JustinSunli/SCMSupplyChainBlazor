using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "仓库调拨详情单")]
    public class DevolveDetail : PersistPoco
    {
        [Display(Name = "仓库调拨详情单号")]
        [Required(ErrorMessage = "仓库调拨详情单号不能为空")]
        [StringLength(100, ErrorMessage = "仓库调拨详情单号超最长限制,100内")]
        public string DevDID { get; set; }

        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }


        [Display(Name = "调拨单号")]
        public Guid? DevolvesID { get; set; }
        [Display(Name = "调拨单号")]
        public Devolves Devolves { get; set; }

        [Display(Name = "数量")]
        public int DevDAmount { get; set; }


        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string DevDDesc { get; set; }
    }
}
