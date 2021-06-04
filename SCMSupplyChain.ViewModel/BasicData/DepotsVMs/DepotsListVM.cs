using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.DepotsVMs
{
    public partial class DepotsListVM : BasePagedListVM<Depots_View, DepotsSearcher>
    {

        protected override IEnumerable<IGridColumn<Depots_View>> InitGridHeader()
        {
            return new List<GridColumn<Depots_View>>{
                this.MakeGridHeader(x => x.DepotName),
                this.MakeGridHeader(x => x.DepotMan),
                this.MakeGridHeader(x => x.DepotTelephone),
                this.MakeGridHeader(x => x.DepotAddress),
                this.MakeGridHeader(x => x.DepotDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Depots_View> GetSearchQuery()
        {
            var query = DC.Set<Depots>()
                .CheckContain(Searcher.DepotName, x=>x.DepotName)
                .CheckContain(Searcher.DepotMan, x=>x.DepotMan)
                .CheckContain(Searcher.DepotAddress, x=>x.DepotAddress)
                .Select(x => new Depots_View
                {
				    ID = x.ID,
                    DepotName = x.DepotName,
                    DepotMan = x.DepotMan,
                    DepotTelephone = x.DepotTelephone,
                    DepotAddress = x.DepotAddress,
                    DepotDesc = x.DepotDesc,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class Depots_View : Depots{

    }
}
