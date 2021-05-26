using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "报损单详单")]
    public class LostDetail: BasePoco
    {
        [Display(Name = "报损详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过最长限制,200内")]
        public string LDID { get; set; }

        [Display(Name ="报损单")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid LostsID { get; set; }

        [Display(Name = "报损单")]
        public Losts Losts { get; set; }

        [Display(Name ="商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int LDAmount { get; set; }

        [Display(Name ="价格")]
        [Required(ErrorMessage= "价格不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double LDPrice { get; set; }

        [Display(Name ="备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string LDDesc { get; set; }
    }
}
