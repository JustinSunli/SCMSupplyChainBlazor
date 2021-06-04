using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name ="出入库记录")]
    public class InOutDepot : PersistPoco
    {
        [Display(Name = "出库记录号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = "{0}超最长限制,100内")]
        public string IODID { get; set; } = "OR" + DateTime.Now.ToString("yyyyMMddhhmmss");

        [Display(Name = "出库类型")]
        public IODType IODType { get; set; }

        [Display(Name = "仓库")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid? DepotsID { get; set; }

        [Display(Name = "仓库")]
        public Depots Depots { get; set; }


        [Display(Name = "描述")]
        [StringLength(500, ErrorMessage = "描述超过最长限制,500内")]
        public string IODDesc { get; set; }
    }
}
