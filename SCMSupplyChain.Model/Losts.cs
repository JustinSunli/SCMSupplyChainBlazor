using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "报损单")]
    public class Losts : BasePoco
    {
        [Display(Name = "报损单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200, ErrorMessage = "{0}超过最长限制,200内")]
        public string LostID { get; set; }

        [Display(Name = "仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid DepotsID { get; set; }

        [Display(Name = "仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Depots Depots { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string LostDesc { get; set; }

        [Display(Name = "状态")]
        public LostState LostState { get; set; }
    }
}
