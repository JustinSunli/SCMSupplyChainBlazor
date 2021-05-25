using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.InOutDepotVMs
{
    public partial class InOutDepotListVM : BasePagedListVM<InOutDepot_View, InOutDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<InOutDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<InOutDepot_View>>{
                this.MakeGridHeader(x => x.IODID),
                this.MakeGridHeader(x => x.IODType),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.IODDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<InOutDepot_View> GetSearchQuery()
        {
            var query = DC.Set<InOutDepot>()
                .CheckContain(Searcher.IODID, x=>x.IODID)
                .CheckEqual(Searcher.IODType, x=>x.IODType)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .Select(x => new InOutDepot_View
                {
				    ID = x.ID,
                    IODID = x.IODID,
                    IODType = x.IODType,
                    DepotName_view = x.Depots.DepotName,
                    IODDesc = x.IODDesc,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class InOutDepot_View : InOutDepot{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
