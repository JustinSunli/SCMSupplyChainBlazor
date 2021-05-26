using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.ProduceInDepotVMs
{
    public partial class ProduceInDepotSearcher : BaseSearcher
    {
        [Display(Name = "生产入库单号")]
        public String PIDID { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "状态")]
        public PIDState? PIDState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
