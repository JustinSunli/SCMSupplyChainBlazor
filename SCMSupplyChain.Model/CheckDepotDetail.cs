using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = " 盘点详情单")]
    public class CheckDepotDetail : PersistPoco
    {
        [Display(Name = "盘点单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? CheckDepotID { get; set; }

        [Display(Name = "盘点单号")]
        public CheckDepot CheckDepot { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "盘点数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]

        public int CDDAmount1 { get; set; }

        [Display(Name = "应有数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int DevAmount2 { get; set; }

        [Display(Name ="备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string OODDesc { get; set; }
    }
}
