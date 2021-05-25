using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.SaleReturnVMs
{
    public partial class SaleReturnSearcher : BaseSearcher
    {
        [Display(Name = "销售退货单号")]
        public String SRID { get; set; }
        [Display(Name = "客户")]
        public Guid? CustomersID { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "状态")]
        public SRState? SRState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
