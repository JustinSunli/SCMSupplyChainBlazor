using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.StocksVMs
{
    public partial class StocksListVM : BasePagedListVM<Stocks_View, StocksSearcher>
    {

        protected override IEnumerable<IGridColumn<Stocks_View>> InitGridHeader()
        {
            return new List<GridColumn<Stocks_View>>{
                this.MakeGridHeader(x => x.StockID),
                this.MakeGridHeader(x => x.PPName_view),
                this.MakeGridHeader(x => x.StockInDate),
                this.MakeGridHeader(x => x.StockState),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Stocks_View> GetSearchQuery()
        {
            var query = DC.Set<Stocks>()
                .CheckContain(Searcher.StockID, x=>x.StockID)
                .CheckEqual(Searcher.ProductLendID, x=>x.ProductLendID)
                .CheckBetween(Searcher.StockInDate?.GetStartTime(), Searcher.StockInDate?.GetEndTime(), x => x.StockInDate, includeMax: false)
                .CheckEqual(Searcher.StockState, x=>x.StockState)
                .Select(x => new Stocks_View
                {
				    ID = x.ID,
                    StockID = x.StockID,
                    PPName_view = x.ProductLend.PPName,
                    StockInDate = x.StockInDate,
                    StockState = x.StockState,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class Stocks_View : Stocks{
        [Display(Name = "供货商名称")]
        public String PPName_view { get; set; }

    }
}
