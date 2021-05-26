using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.ProduceInDepotVMs
{
    public partial class ProduceInDepotListVM : BasePagedListVM<ProduceInDepot_View, ProduceInDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<ProduceInDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<ProduceInDepot_View>>{
                this.MakeGridHeader(x => x.PIDID),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.PDIDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ProduceInDepot_View> GetSearchQuery()
        {
            var query = DC.Set<ProduceInDepot>()
                .CheckContain(Searcher.PIDID, x=>x.PIDID)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .Select(x => new ProduceInDepot_View
                {
				    ID = x.ID,
                    PIDID = x.PIDID,
                    DepotName_view = x.Depots.DepotName,
                    PDIDesc = x.PDIDesc,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ProduceInDepot_View : ProduceInDepot{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
