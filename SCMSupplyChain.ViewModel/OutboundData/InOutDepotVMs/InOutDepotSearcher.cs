using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.InOutDepotVMs
{
    public partial class InOutDepotSearcher : BaseSearcher
    {
        [Display(Name = "出库记录号")]
        public String IODID { get; set; }
        [Display(Name = "出库类型")]
        public IODType? IODType { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }

        protected override void InitVM()
        {
        }

    }
}
