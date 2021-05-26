using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.StockInDepotVMs
{
    public partial class StockInDepotListVM : BasePagedListVM<StockInDepot_View, StockInDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<StockInDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<StockInDepot_View>>{
                this.MakeGridHeader(x => x.SIDID),
                this.MakeGridHeader(x => x.PPName_view),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.StockID_view),
                this.MakeGridHeader(x => x.SIDDate),
                this.MakeGridHeader(x => x.SIDDeliver),
                this.MakeGridHeader(x => x.SIDFreight),
                this.MakeGridHeader(x => x.SIDData),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<StockInDepot_View> GetSearchQuery()
        {
            var query = DC.Set<StockInDepot>()
                .CheckContain(Searcher.SIDID, x=>x.SIDID)
                .CheckEqual(Searcher.ProductLendID, x=>x.ProductLendID)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.StocksID, x=>x.StocksID)
                .CheckBetween(Searcher.SIDDate?.GetStartTime(), Searcher.SIDDate?.GetEndTime(), x => x.SIDDate, includeMax: false)
                .CheckContain(Searcher.SIDDeliver, x=>x.SIDDeliver)
                .CheckEqual(Searcher.SIDData, x=>x.SIDData)
                .Select(x => new StockInDepot_View
                {
				    ID = x.ID,
                    SIDID = x.SIDID,
                    PPName_view = x.ProductLend.PPName,
                    DepotName_view = x.Depots.DepotName,
                    StockID_view = x.Stocks.StockID,
                    SIDDate = x.SIDDate,
                    SIDDeliver = x.SIDDeliver,
                    SIDFreight = x.SIDFreight,
                    SIDData = x.SIDData,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class StockInDepot_View : StockInDepot{
        [Display(Name = "供货商名称")]
        public String PPName_view { get; set; }
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }
        [Display(Name = "采购单号")]
        public String StockID_view { get; set; }

    }
}
