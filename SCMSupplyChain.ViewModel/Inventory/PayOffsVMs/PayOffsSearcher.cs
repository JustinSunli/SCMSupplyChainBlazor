using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.PayOffsVMs
{
    public partial class PayOffsSearcher : BaseSearcher
    {
        [Display(Name = "报溢单号")]
        public String POID { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "状态")]
        public POState? POState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
