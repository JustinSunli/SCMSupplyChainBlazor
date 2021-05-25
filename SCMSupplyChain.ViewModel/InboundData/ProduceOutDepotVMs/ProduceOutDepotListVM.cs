using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.ProduceOutDepotVMs
{
    public partial class ProduceOutDepotListVM : BasePagedListVM<ProduceOutDepot_View, ProduceOutDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<ProduceOutDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<ProduceOutDepot_View>>{
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.PODState),
                this.MakeGridHeader(x => x.PODDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ProduceOutDepot_View> GetSearchQuery()
        {
            var query = DC.Set<ProduceOutDepot>()
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.PODState, x=>x.PODState)
                .Select(x => new ProduceOutDepot_View
                {
				    ID = x.ID,
                    DepotName_view = x.Depots.DepotName,
                    PODState = x.PODState,
                    PODDesc = x.PODDesc,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ProduceOutDepot_View : ProduceOutDepot{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
