using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.DepotStockVMs
{
    public partial class DepotStockListVM : BasePagedListVM<DepotStock_View, DepotStockSearcher>
    {

        protected override IEnumerable<IGridColumn<DepotStock_View>> InitGridHeader()
        {
            return new List<GridColumn<DepotStock_View>>{
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.ProdName_view),
                this.MakeGridHeader(x => x.DSAmount),
                this.MakeGridHeader(x => x.DSPrice),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<DepotStock_View> GetSearchQuery()
        {
            var query = DC.Set<DepotStock>()
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.ProductsID, x=>x.ProductsID)
                .CheckEqual(Searcher.DSAmount, x=>x.DSAmount)
                .Select(x => new DepotStock_View
                {
				    ID = x.ID,
                    DepotName_view = x.Depots.DepotName,
                    ProdName_view = x.Products.ProdName,
                    DSAmount = x.DSAmount,
                    DSPrice = x.DSPrice,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class DepotStock_View : DepotStock{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }
        [Display(Name = "商品名称")]
        public String ProdName_view { get; set; }

    }
}
