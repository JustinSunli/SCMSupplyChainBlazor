using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductsVMs
{
    public partial class ProductsListVM : BasePagedListVM<Products_View, ProductsSearcher>
    {

        protected override IEnumerable<IGridColumn<Products_View>> InitGridHeader()
        {
            return new List<GridColumn<Products_View>>{
                this.MakeGridHeader(x => x.PUName_view),
                this.MakeGridHeader(x => x.PTName_view),
                this.MakeGridHeader(x => x.ProMax),
                this.MakeGridHeader(x => x.ProMin),
                this.MakeGridHeader(x => x.ProdName),
                this.MakeGridHeader(x => x.ProWorkShop),
                this.MakeGridHeader(x => x.ProInPrice),
                this.MakeGridHeader(x => x.ProPrice),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Products_View> GetSearchQuery()
        {
            var query = DC.Set<Products>()
                .CheckEqual(Searcher.ProductUnitID, x=>x.ProductUnitID)
                .CheckEqual(Searcher.ProductTypesID, x=>x.ProductTypesID)
                .CheckContain(Searcher.ProdName, x=>x.ProdName)
                .CheckContain(Searcher.ProWorkShop, x=>x.ProWorkShop)
                .Select(x => new Products_View
                {
				    ID = x.ID,
                    PUName_view = x.ProductUnit.PUName,
                    PTName_view = x.ProductTypes.PTName,
                    ProMax = x.ProMax,
                    ProMin = x.ProMin,
                    ProdName = x.ProdName,
                    ProWorkShop = x.ProWorkShop,
                    ProInPrice = x.ProInPrice,
                    ProPrice = x.ProPrice,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Products_View : Products{
        [Display(Name = "单位名称")]
        public String PUName_view { get; set; }
        [Display(Name = "名称")]
        public String PTName_view { get; set; }

    }
}
