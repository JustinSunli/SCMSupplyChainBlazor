using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "商品")]
    public class Products : PersistPoco
    {
        [Display(Name = "库存上限")]
        public int ProMax { get; set; }
        [Display(Name = "库存下限")]
        public int ProMin { get; set; }

        [Display(Name = "商品名称")]
        public string ProdName { get; set; }

        [Display(Name = "生产厂家")]
        public string ProWorkShop { get; set; }

        [Display(Name = "条码")]
        public Guid? PhotoId { get; set; }
        [Display(Name = "条码")]
        public FileAttachment Photo { get; set; }

        [Display(Name = "预设进价")]
        public double ProInPrice { get; set; }

        [Display(Name = "售价")]
        public double ProPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string ProDesc { get; set; }

    }
}
