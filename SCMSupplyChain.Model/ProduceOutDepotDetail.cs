using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "生产领料详情")]
    public class ProduceOutDepotDetail:PersistPoco
    {
        [Display(Name = "生产领料详情单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过最长限制,200内")]
        public string PODID { get; set; }

        [Display(Name = "生产领料单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? ProduceOutDepotID { get; set; }

        [Display(Name = "生产领料单号")]
        public ProduceOutDepot ProduceOutDepot { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "请输入正确的{0}")]
        public int PODDAmount { get; set; }

        [Display(Name = "售价")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"(?!^0*(\.0{1,2})?$)^\d{1,13}(\.\d{1,2})?$", ErrorMessage = "请输入正确的{0}")]
        public double PODDPrice { get; set; }

        [Display(Name ="备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")] 
        public int PODDDesc { get; set; }

    }
}
