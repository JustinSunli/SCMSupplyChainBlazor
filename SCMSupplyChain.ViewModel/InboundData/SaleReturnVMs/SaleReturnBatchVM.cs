using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.SaleReturnVMs
{
    public partial class SaleReturnBatchVM : BaseBatchVM<SaleReturn, SaleReturn_BatchEdit>
    {
        public SaleReturnBatchVM()
        {
            ListVM = new SaleReturnListVM();
            LinkedVM = new SaleReturn_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class SaleReturn_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
