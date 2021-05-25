using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.ProduceInDepotVMs
{
    public partial class ProduceInDepotBatchVM : BaseBatchVM<ProduceInDepot, ProduceInDepot_BatchEdit>
    {
        public ProduceInDepotBatchVM()
        {
            ListVM = new ProduceInDepotListVM();
            LinkedVM = new ProduceInDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProduceInDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
