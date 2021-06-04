using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.CustomersVMs
{
    public partial class CustomersListVM : BasePagedListVM<Customers_View, CustomersSearcher>
    {

        protected override IEnumerable<IGridColumn<Customers_View>> InitGridHeader()
        {
            return new List<GridColumn<Customers_View>>{
                this.MakeGridHeader(x => x.CusName),
                this.MakeGridHeader(x => x.CusGrade),
                this.MakeGridHeader(x => x.CusCompany),
                this.MakeGridHeader(x => x.CusMan),
                this.MakeGridHeader(x => x.CusTelephone),
                this.MakeGridHeader(x => x.CusDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Customers_View> GetSearchQuery()
        {
            var query = DC.Set<Customers>()
                .CheckContain(Searcher.CusName, x=>x.CusName)
                .CheckEqual(Searcher.CusGrade, x=>x.CusGrade)
                .CheckContain(Searcher.CusCompany, x=>x.CusCompany)
                .Select(x => new Customers_View
                {
				    ID = x.ID,
                    CusName = x.CusName,
                    CusGrade = x.CusGrade,
                    CusCompany = x.CusCompany,
                    CusMan = x.CusMan,
                    CusTelephone = x.CusTelephone,
                    CusDesc = x.CusDesc,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class Customers_View : Customers{

    }
}
