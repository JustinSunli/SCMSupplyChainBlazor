using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name ="盘点单")]
    public class CheckDepot : PersistPoco
    {

        [Display(Name = "调出仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "调出仓库")]
        public Depots Depots { get; set; }

        [Display(Name = "盘点人")]
        public Guid? FrameworkUserID { get; set; }
        [Display(Name = "盘点人")]
        public FrameworkUserBase FrameworkUserBase { get; set; }


        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注超过限制,500内")]
        public string CDDesc { get; set; }
        [Display(Name ="状态")]
        public CDState CDState { get; set; }
    }
}
