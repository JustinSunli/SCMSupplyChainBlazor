using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.OtherOutDepotVMs
{
    public partial class OtherOutDepotListVM : BasePagedListVM<OtherOutDepot_View, OtherOutDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<OtherOutDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<OtherOutDepot_View>>{
                this.MakeGridHeader(x => x.OODID),
                this.MakeGridHeader(x => x.OODState),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.OODDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<OtherOutDepot_View> GetSearchQuery()
        {
            var query = DC.Set<OtherOutDepot>()
                .CheckContain(Searcher.OODID, x=>x.OODID)
                .CheckEqual(Searcher.OODState, x=>x.OODState)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .Select(x => new OtherOutDepot_View
                {
				    ID = x.ID,
                    OODID = x.OODID,
                    OODState = x.OODState,
                    DepotName_view = x.Depots.DepotName,
                    OODDesc = x.OODDesc,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class OtherOutDepot_View : OtherOutDepot{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
