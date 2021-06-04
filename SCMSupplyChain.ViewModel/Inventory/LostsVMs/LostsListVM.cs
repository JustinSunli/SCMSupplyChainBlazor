using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.LostsVMs
{
    public partial class LostsListVM : BasePagedListVM<Losts_View, LostsSearcher>
    {

        protected override IEnumerable<IGridColumn<Losts_View>> InitGridHeader()
        {
            return new List<GridColumn<Losts_View>>{
                this.MakeGridHeader(x => x.LostID),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.LostDesc),
                this.MakeGridHeader(x => x.LostState),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Losts_View> GetSearchQuery()
        {
            var query = DC.Set<Losts>()
                .CheckContain(Searcher.LostID, x=>x.LostID)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.LostState, x=>x.LostState)
                .Select(x => new Losts_View
                {
				    ID = x.ID,
                    LostID = x.LostID,
                    DepotName_view = x.Depots.DepotName,
                    LostDesc = x.LostDesc,
                    LostState = x.LostState,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class Losts_View : Losts{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
