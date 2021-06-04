using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "生产领料单")]
    public class ProduceOutDepot : PersistPoco
    {

        [Display(Name = "仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? DepotsID { get; set; }

        [Display(Name = "仓库")]
        public Depots Depots { get; set; }

        [Display(Name = "状态")]
        public PODState PODState { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string PODDesc { get; set; }
    }

}
