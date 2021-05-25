using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.OtherOutDepotVMs
{
    public partial class OtherOutDepotBatchVM : BaseBatchVM<OtherOutDepot, OtherOutDepot_BatchEdit>
    {
        public OtherOutDepotBatchVM()
        {
            ListVM = new OtherOutDepotListVM();
            LinkedVM = new OtherOutDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class OtherOutDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
