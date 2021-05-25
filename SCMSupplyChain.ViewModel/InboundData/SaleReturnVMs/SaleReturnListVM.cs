using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.SaleReturnVMs
{
    public partial class SaleReturnListVM : BasePagedListVM<SaleReturn_View, SaleReturnSearcher>
    {

        protected override IEnumerable<IGridColumn<SaleReturn_View>> InitGridHeader()
        {
            return new List<GridColumn<SaleReturn_View>>{
                this.MakeGridHeader(x => x.SRID),
                this.MakeGridHeader(x => x.CusName_view),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.SRState),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SaleReturn_View> GetSearchQuery()
        {
            var query = DC.Set<SaleReturn>()
                .CheckContain(Searcher.SRID, x=>x.SRID)
                .CheckEqual(Searcher.CustomersID, x=>x.CustomersID)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.SRState, x=>x.SRState)
                .Select(x => new SaleReturn_View
                {
				    ID = x.ID,
                    SRID = x.SRID,
                    CusName_view = x.Customers.CusName,
                    DepotName_view = x.Depots.DepotName,
                    SRState = x.SRState,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SaleReturn_View : SaleReturn{
        [Display(Name = "客户名称")]
        public String CusName_view { get; set; }
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
