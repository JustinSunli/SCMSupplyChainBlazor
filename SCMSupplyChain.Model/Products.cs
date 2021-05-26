using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "商品")]
    public class Products : PersistPoco
    {
        [Display(Name = "商品规格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductUnitID { get; set; }

        [Display(Name = "商品规格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public ProductUnit ProductUnit { get; set; }

        [Display(Name = "商品类别")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ProductTypesID { get; set; }

        [Display(Name = "商品类别")]
        [Required(ErrorMessage = "{0}不能为空")]
        public ProductTypes ProductTypes { get; set; }

        [Display(Name = "库存上限")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的库存")]
        public int ProMax { get; set; }

        [Display(Name = "库存下限")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的库存")]
        public int ProMin { get; set; }

        [Display(Name = "商品名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ProdName { get; set; }

        [Display(Name = "生产厂家")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ProWorkShop { get; set; }

        [Display(Name = "条码")]
        public Guid? PhotoId { get; set; }
        [Display(Name = "条码")]
        public FileAttachment Photo { get; set; }

        [Display(Name = "预设进价")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的预设进价")]
        public double ProInPrice { get; set; }

        [Display(Name = "售价")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的售价")]
        public double ProPrice { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string ProDesc { get; set; }

    }
}
