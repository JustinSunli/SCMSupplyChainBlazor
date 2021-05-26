using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    public class ProduceInDepotDeteil : PersistPoco
    {
        [Display(Name = "生产入库单详情单号")]
        [Required(ErrorMessage = "生产入库单详情单号不能为空")]
        [StringLength(500, ErrorMessage = "生产入库单详情单号超过最长限制")]
        public string PIDDID { get; set; }

        [Display(Name = "商品")]
        [Required(ErrorMessage = "商品不能为空")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        [Required(ErrorMessage = "商品不能为空")]
        public Products Products { get; set; }

        [Display(Name = "生产入库单号")]
        [Required(ErrorMessage = "生产入库单号不能为空")]
        public Guid ProduceInDepotID { get; set; }
        [Display(Name = "生产入库单号")]
        [Required(ErrorMessage = "生产入库单号不能为空")]
        public ProduceInDepot ProduceInDepot { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "数量不能为空")]
        public int PIDDAmount { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "价格不能为空")]
        public double PIDDPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string PIDDDesc { get; set; }
    }
}
