using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductUnitVMs
{
    public partial class ProductUnitListVM : BasePagedListVM<ProductUnit_View, ProductUnitSearcher>
    {

        protected override IEnumerable<IGridColumn<ProductUnit_View>> InitGridHeader()
        {
            return new List<GridColumn<ProductUnit_View>>{
                this.MakeGridHeader(x => x.PUName),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ProductUnit_View> GetSearchQuery()
        {
            var query = DC.Set<ProductUnit>()
                .CheckContain(Searcher.PUName, x=>x.PUName)
                .Select(x => new ProductUnit_View
                {
				    ID = x.ID,
                    PUName = x.PUName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ProductUnit_View : ProductUnit{

    }
}
