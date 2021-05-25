using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.LostsVMs
{
    public partial class LostsBatchVM : BaseBatchVM<Losts, Losts_BatchEdit>
    {
        public LostsBatchVM()
        {
            ListVM = new LostsListVM();
            LinkedVM = new Losts_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Losts_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
