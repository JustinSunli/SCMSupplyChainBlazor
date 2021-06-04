using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.PayOffsVMs
{
    public partial class PayOffsListVM : BasePagedListVM<PayOffs_View, PayOffsSearcher>
    {

        protected override IEnumerable<IGridColumn<PayOffs_View>> InitGridHeader()
        {
            return new List<GridColumn<PayOffs_View>>{
                this.MakeGridHeader(x => x.POID),
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.POState),
                this.MakeGridHeader(x => x.PODesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PayOffs_View> GetSearchQuery()
        {
            var query = DC.Set<PayOffs>()
                .CheckContain(Searcher.POID, x=>x.POID)
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.POState, x=>x.POState)
                .Select(x => new PayOffs_View
                {
				    ID = x.ID,
                    POID = x.POID,
                    DepotName_view = x.Depots.DepotName,
                    POState = x.POState,
                    PODesc = x.PODesc,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class PayOffs_View : PayOffs{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }

    }
}
