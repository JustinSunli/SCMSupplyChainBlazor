using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.StockInDepotVMs
{
    public partial class StockInDepotVM : BaseCRUDVM<StockInDepot>
    {

        public StockInDepotVM()
        {
            SetInclude(x => x.ProductLend);
            SetInclude(x => x.Depots);
            SetInclude(x => x.Stocks);
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
