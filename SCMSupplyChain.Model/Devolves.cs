using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "仓库调拨单")]
    public class Devolves: PersistPoco
    {
        [Display(Name = "仓库调拨单号")]
        [Required(ErrorMessage = "仓库调拨单号不能为空")]
        [StringLength(100, ErrorMessage = "仓库调拨单号超最长限制,100内")]
        public string DevID { get; set; }

        [Display(Name = "调出仓库")]
        public Guid? DepotsDevOutID { get; set; }
        [Display(Name = "调出仓库")]
        public Depots DepotsDevOut { get; set; }

        [Display(Name = "调入仓库")]
        public Guid? DepotsDevInID { get; set; }
        [Display(Name = "调入仓库")]
        public Depots DepotsDevIn { get; set; }

        [Display(Name = "调拨人")]
        public Guid? FrameworkUserID { get; set; }
        [Display(Name = "调拨人")]
        public FrameworkUserBase FrameworkUserBase { get; set; }

        [Display(Name = "调拨时间")]
        [Required(ErrorMessage = "调拨时间不能为空")]
        public DateTime? DevDate { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string DevState { get; set; }

    }
}
