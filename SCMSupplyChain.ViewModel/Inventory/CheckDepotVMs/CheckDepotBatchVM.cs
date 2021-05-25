using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.CheckDepotVMs
{
    public partial class CheckDepotBatchVM : BaseBatchVM<CheckDepot, CheckDepot_BatchEdit>
    {
        public CheckDepotBatchVM()
        {
            ListVM = new CheckDepotListVM();
            LinkedVM = new CheckDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class CheckDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
