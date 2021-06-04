using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "仓库调拨详情单")]
    public class DevolveDetail : PersistPoco
    {
        [Display(Name = "仓库调拨详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超最长限制,100内")]
        public string DevDID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? ProductsID { get; set; }

        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "调拨单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? DevolvesID { get; set; }

        [Display(Name = "调拨单号")]
        public Devolves Devolves { get; set; }

        [Display(Name = "数量")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int DevDAmount { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string DevDDesc { get; set; }
    }
}
