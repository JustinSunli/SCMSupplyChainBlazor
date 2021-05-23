using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;


namespace SCMSupplyChain.Model
{
    [Display(Name = "其它入库单")]
    public class OtherInDepot: BasePoco
    {
        [Display(Name = "其它入库单号")]
        [Required(ErrorMessage = "其它入库单号不能为空")]
        [StringLength(200, ErrorMessage = "其它入库单号超过限制,200内")]
        public string OIDID { get; set; }

        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "仓库")]
        public Depots Depots { get; set; }

        [Display(Name ="审核状态")]
        public OIDState OIDState { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string OIDDesc { get; set; }
        
    }
}
