using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "其他出库单")]
    public class OtherOutDepot : PersistPoco
    {

        [Display(Name = "其他出库单号")]
        [Required(ErrorMessage = "其他出库单号不能为空")]
        [StringLength(200,ErrorMessage = "其他出库单号超过限制,200内")]
        public string OODID { get; set; }

        public OODState OODState { get; set; }

        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "仓库")]
        public Depots Depots { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string OODDesc { get; set; }

    }
}
