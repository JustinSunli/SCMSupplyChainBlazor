using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.DepotStockVMs
{
    public partial class DepotStockBatchVM : BaseBatchVM<DepotStock, DepotStock_BatchEdit>
    {
        public DepotStockBatchVM()
        {
            ListVM = new DepotStockListVM();
            LinkedVM = new DepotStock_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class DepotStock_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
