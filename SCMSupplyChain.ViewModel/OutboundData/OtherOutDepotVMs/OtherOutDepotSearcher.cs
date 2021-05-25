using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.OtherOutDepotVMs
{
    public partial class OtherOutDepotSearcher : BaseSearcher
    {
        [Display(Name = "其他出库单号")]
        public String OODID { get; set; }
        [Display(Name = "状态")]
        public OODState? OODState { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }

        protected override void InitVM()
        {
        }

    }
}
