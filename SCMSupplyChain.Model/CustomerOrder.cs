using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name ="客户订单")]
    public class CustomerOrder: PersistPoco
    {
        [Display(Name ="客户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid CustomersID { get; set; }

        [Display(Name = "客户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Customers Customers { get; set; }

        [Display(Name = "交货时间")]
        public DateTime? CORefDate { get; set; }

        [Display(Name ="状态")]
        public COState COState { get; set; }

        [Display(Name ="备注")]
        [StringLength(500,ErrorMessage ="备注超过最长限制")]
        public string CODesc { get; set; }
    }
}
