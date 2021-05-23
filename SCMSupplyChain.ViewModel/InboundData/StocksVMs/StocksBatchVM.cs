using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.StocksVMs
{
    public partial class StocksBatchVM : BaseBatchVM<Stocks, Stocks_BatchEdit>
    {
        public StocksBatchVM()
        {
            ListVM = new StocksListVM();
            LinkedVM = new Stocks_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Stocks_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
