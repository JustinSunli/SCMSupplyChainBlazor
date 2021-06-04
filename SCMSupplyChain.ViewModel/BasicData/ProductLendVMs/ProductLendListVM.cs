using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductLendVMs
{
    public partial class ProductLendListVM : BasePagedListVM<ProductLend_View, ProductLendSearcher>
    {

        protected override IEnumerable<IGridColumn<ProductLend_View>> InitGridHeader()
        {
            return new List<GridColumn<ProductLend_View>>{
                this.MakeGridHeader(x => x.PPName),
                this.MakeGridHeader(x => x.PPCompany),
                this.MakeGridHeader(x => x.PPMan),
                this.MakeGridHeader(x => x.PPTel),
                this.MakeGridHeader(x => x.PPAddress),
                this.MakeGridHeader(x => x.PPFax),
                this.MakeGridHeader(x => x.Email),
                this.MakeGridHeader(x => x.PPUrl),
                this.MakeGridHeader(x => x.PPBank),
                this.MakeGridHeader(x => x.PPGoods),
                this.MakeGridHeader(x => x.PPDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ProductLend_View> GetSearchQuery()
        {
            var query = DC.Set<ProductLend>()
                .CheckContain(Searcher.PPName, x=>x.PPName)
                .CheckContain(Searcher.PPCompany, x=>x.PPCompany)
                .CheckContain(Searcher.PPBank, x=>x.PPBank)
                .Select(x => new ProductLend_View
                {
				    ID = x.ID,
                    PPName = x.PPName,
                    PPCompany = x.PPCompany,
                    PPMan = x.PPMan,
                    PPTel = x.PPTel,
                    PPAddress = x.PPAddress,
                    PPFax = x.PPFax,
                    Email = x.Email,
                    PPUrl = x.PPUrl,
                    PPBank = x.PPBank,
                    PPGoods = x.PPGoods,
                    PPDesc = x.PPDesc,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class ProductLend_View : ProductLend{

    }
}
