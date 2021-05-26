using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "客户订单详单")]
    public class CustomerOrderDetail : PersistPoco
    {
        [Display(Name = "客户订单")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid CustomerOrderID { get; set; }

        [Display(Name = "客户订单")]
        public CustomerOrder CustomerOrder { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductsID { get; set; }

        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name = "数量")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的数量")]
        public int CODAmount { get; set; }

        [Display(Name = "价格")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的价格")]
        public double CODPrice { get; set; }

        [Display(Name = "折扣")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的折扣")]
        public double CODDiscont { get; set; }

        [Display(Name = "折后价")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的折后价")]
        public decimal CODDisPrice { get; set; }

        [Display(Name = "已销售数量")]
        public long CODSale { get; set; }

        [Display(Name ="备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string CODDesc { get; set; }
    }
}
