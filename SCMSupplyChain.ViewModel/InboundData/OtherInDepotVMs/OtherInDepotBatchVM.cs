using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.OtherInDepotVMs
{
    public partial class OtherInDepotBatchVM : BaseBatchVM<OtherInDepot, OtherInDepot_BatchEdit>
    {
        public OtherInDepotBatchVM()
        {
            ListVM = new OtherInDepotListVM();
            LinkedVM = new OtherInDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class OtherInDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
