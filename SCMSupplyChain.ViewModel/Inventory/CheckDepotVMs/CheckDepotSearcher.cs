using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.CheckDepotVMs
{
    public partial class CheckDepotSearcher : BaseSearcher
    {
        [Display(Name = "调出仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "盘点人")]
        public Guid? FrameworkUserID { get; set; }
        [Display(Name = "状态")]
        public CDState? CDState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
