using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductTypesVMs
{
    public partial class ProductTypesListVM : BasePagedListVM<ProductTypes_View, ProductTypesSearcher>
    {

        protected override IEnumerable<IGridColumn<ProductTypes_View>> InitGridHeader()
        {
            return new List<GridColumn<ProductTypes_View>>{
                this.MakeGridHeader(x => x.PTName_view),
                this.MakeGridHeader(x => x.PTName),
                this.MakeGridHeader(x => x.PTDes),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ProductTypes_View> GetSearchQuery()
        {
            var query = DC.Set<ProductTypes>()
                .CheckEqual(Searcher.ParentId, x=>x.ParentId)
                .CheckContain(Searcher.PTName, x=>x.PTName)
                .Select(x => new ProductTypes_View
                {
				    ID = x.ID,
                    PTName_view = x.Parent.PTName,
                    PTName = x.PTName,
                    PTDes = x.PTDes,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class ProductTypes_View : ProductTypes{
        [Display(Name = "名称")]
        public String PTName_view { get; set; }

    }
}
