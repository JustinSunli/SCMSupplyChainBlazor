using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.OtherInDepotVMs
{
    public partial class OtherInDepotListVM : BasePagedListVM<OtherInDepot_View, OtherInDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<OtherInDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<OtherInDepot_View>>{
                this.MakeGridHeader(x => x.OIDID),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.OIDState),
                this.MakeGridHeader(x => x.OIDDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<OtherInDepot_View> GetSearchQuery()
        {
            var query = DC.Set<OtherInDepot>()
                .CheckContain(Searcher.OIDID, x => x.OIDID)
                .CheckEqual(Searcher.DepotsID, x => x.DepotsID)
                .CheckEqual(Searcher.OIDState, x => x.OIDState)
                .Select(x => new OtherInDepot_View
                {
                    ID = x.ID,
                    OIDID = x.OIDID,
                    DepotName_view = x.Depots.DepotName,
                    OIDState = x.OIDState,
                    OIDDesc = x.OIDDesc,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class OtherInDepot_View : OtherInDepot
    {
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
