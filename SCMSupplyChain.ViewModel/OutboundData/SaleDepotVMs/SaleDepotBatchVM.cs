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
    public partial class SaleDepotBatchVM : BaseBatchVM<SaleDepot, SaleDepot_BatchEdit>
    {
        public SaleDepotBatchVM()
        {
            ListVM = new SaleDepotListVM();
            LinkedVM = new SaleDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class SaleDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
