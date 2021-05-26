using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "报溢单")]
    public class PayOffs: PersistPoco
    {
        [Display(Name ="报溢单号")]
        [Required(ErrorMessage="报溢单号不能为空")]
        [StringLength(200,ErrorMessage= "报溢单号超过最长限制,200内")]
        public string POID { get; set; }

        [Display(Name ="仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "仓库")]
        public Depots Depots { get; set; }

        [Display(Name ="状态")]
        public POState POState { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过最长限制,500内")]
        public string PODesc { get; set; }
    }
}
