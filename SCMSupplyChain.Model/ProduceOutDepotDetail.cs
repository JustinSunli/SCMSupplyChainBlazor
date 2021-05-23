using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "生产领料详情")]
    public class ProduceOutDepotDetail:PersistPoco
    {
        [Display(Name = "生产领料单号")]
        [Required(ErrorMessage = "生产领料单号不能为空")]
        [StringLength(200, ErrorMessage = "生产领料单号超过最长限制,200内")]
        public string PODID { get; set; }

        [Display(Name = "生产领料单号")]
        public Guid? ProduceOutDepotID { get; set; }
        [Display(Name = "生产领料单号")]
        public ProduceOutDepot ProduceOutDepot { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "数量不能为空")]
        public int PODDAmount { get; set; }

        [Display(Name = "售价")]
        [Required(ErrorMessage = "售价不能为空")]
        public double PODDPrice { get; set; }

        [Display(Name ="备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")] 
        public int PODDDesc { get; set; }

    }
}
