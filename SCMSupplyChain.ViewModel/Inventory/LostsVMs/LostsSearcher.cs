using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.LostsVMs
{
    public partial class LostsSearcher : BaseSearcher
    {
        [Display(Name = "报损单号")]
        public String LostID { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "状态")]
        public LostState? LostState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
