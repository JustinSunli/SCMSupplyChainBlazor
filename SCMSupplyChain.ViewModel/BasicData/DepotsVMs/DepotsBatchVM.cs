using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.DepotsVMs
{
    public partial class DepotsBatchVM : BaseBatchVM<Depots, Depots_BatchEdit>
    {
        public DepotsBatchVM()
        {
            ListVM = new DepotsListVM();
            LinkedVM = new Depots_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Depots_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
