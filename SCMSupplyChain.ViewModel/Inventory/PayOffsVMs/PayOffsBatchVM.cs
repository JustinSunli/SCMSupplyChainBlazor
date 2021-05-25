using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.PayOffsVMs
{
    public partial class PayOffsBatchVM : BaseBatchVM<PayOffs, PayOffs_BatchEdit>
    {
        public PayOffsBatchVM()
        {
            ListVM = new PayOffsListVM();
            LinkedVM = new PayOffs_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PayOffs_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
