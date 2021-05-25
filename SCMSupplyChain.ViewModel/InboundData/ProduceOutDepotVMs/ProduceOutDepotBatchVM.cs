using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.ProduceOutDepotVMs
{
    public partial class ProduceOutDepotBatchVM : BaseBatchVM<ProduceOutDepot, ProduceOutDepot_BatchEdit>
    {
        public ProduceOutDepotBatchVM()
        {
            ListVM = new ProduceOutDepotListVM();
            LinkedVM = new ProduceOutDepot_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProduceOutDepot_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
