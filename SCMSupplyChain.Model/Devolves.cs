using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "仓库调拨单")]
    public class Devolves: PersistPoco
    {
        [Display(Name = "仓库调拨单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超最长限制,100内")]
        public string DevID { get; set; }

        [Display(Name = "调出仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? DepotsDevOutID { get; set; }

        [Display(Name = "调出仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Depots DepotsDevOut { get; set; }

        [Display(Name = "调入仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? DepotsDevInID { get; set; }

        [Display(Name = "调入仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Depots DepotsDevIn { get; set; }

        [Display(Name = "调拨人")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid FrameworkUserID { get; set; }

        [Display(Name = "调拨人")]
        [Required(ErrorMessage = "{0}不能为空")]
        public FrameworkUserBase FrameworkUserBase { get; set; }

        [Display(Name = "调拨时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime? DevDate { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string DevState { get; set; }

    }
}
