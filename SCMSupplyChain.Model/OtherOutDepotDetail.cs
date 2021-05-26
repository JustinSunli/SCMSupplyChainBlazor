using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "其它入库详情单")]
    public class OtherOutDepotDetail : PersistPoco
    {
        [Display(Name = "其他出库详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过最长限制,200内")]
        public string OODDID { get; set; }

        [Display(Name = "其他出库单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? OtherOutDepotID { get; set; }

        [Display(Name = "其他出库单号")]
        public OtherOutDepot OtherOutDepot { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? ProductsID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int OODDAmount { get; set; }

        [Display(Name = "售价")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double OODDPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string OODDDesc { get; set; }

    }
}
