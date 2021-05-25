using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.SaleDepotVMs
{
    public partial class SaleDepotSearcher : BaseSearcher
    {
        [Display(Name = "销售出库单号")]
        public String SDID { get; set; }
        [Display(Name = "客户")]
        public Guid? CustomersID { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "状态")]
        public SDState? SDState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
