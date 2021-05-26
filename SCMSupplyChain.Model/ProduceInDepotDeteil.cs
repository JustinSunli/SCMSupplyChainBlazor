using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    public class ProduceInDepotDeteil : PersistPoco
    {
        [Display(Name = "生产入库单详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(500, ErrorMessage = "{0}超过最长限制")]
        public string PIDDID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? ProductsID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Products Products { get; set; }

        [Display(Name = "生产入库单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? ProduceInDepotID { get; set; }

        [Display(Name = "生产入库单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public ProduceInDepot ProduceInDepot { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int PIDDAmount { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double PIDDPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string PIDDDesc { get; set; }
    }
}
