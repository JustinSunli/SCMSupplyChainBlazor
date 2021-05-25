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
    public partial class InOutDepotBatchVM : BaseBatchVM<InOutDepot, InOutDepot_BatchEdit>
    {
        public InOutDepotBatchVM()
        {
            ListVM = new InOutDepotListVM();
            LinkedVM = new InOutDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class InOutDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
