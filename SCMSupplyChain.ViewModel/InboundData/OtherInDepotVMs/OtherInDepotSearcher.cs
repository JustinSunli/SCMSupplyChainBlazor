using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.OtherInDepotVMs
{
    public partial class OtherInDepotSearcher : BaseSearcher
    {
        [Display(Name = "其它入库单号")]
        public String OIDID { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "审核状态")]
        public OIDState? OIDState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
