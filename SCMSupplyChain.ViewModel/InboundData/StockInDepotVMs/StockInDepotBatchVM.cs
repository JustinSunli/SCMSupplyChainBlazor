using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.StockInDepotVMs
{
    public partial class StockInDepotBatchVM : BaseBatchVM<StockInDepot, StockInDepot_BatchEdit>
    {
        public StockInDepotBatchVM()
        {
            ListVM = new StockInDepotListVM();
            LinkedVM = new StockInDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class StockInDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
