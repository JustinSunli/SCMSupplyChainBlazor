using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.SaleDepotVMs
{
    public partial class SaleDepotListVM : BasePagedListVM<SaleDepot_View, SaleDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<SaleDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<SaleDepot_View>>{
                this.MakeGridHeader(x => x.SDID),
                this.MakeGridHeader(x => x.CusName_view),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.SDState),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SaleDepot_View> GetSearchQuery()
        {
            var query = DC.Set<SaleDepot>()
                .CheckContain(Searcher.SDID, x=>x.SDID)
                .CheckEqual(Searcher.CustomersID, x=>x.CustomersID)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.SDState, x=>x.SDState)
                .Select(x => new SaleDepot_View
                {
				    ID = x.ID,
                    SDID = x.SDID,
                    CusName_view = x.Customers.CusName,
                    DepotName_view = x.Depots.DepotName,
                    SDState = x.SDState,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class SaleDepot_View : SaleDepot{
        [Display(Name = "客户名称")]
        public String CusName_view { get; set; }
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
