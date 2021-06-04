using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.CheckDepotVMs
{
    public partial class CheckDepotListVM : BasePagedListVM<CheckDepot_View, CheckDepotSearcher>
    {

        protected override IEnumerable<IGridColumn<CheckDepot_View>> InitGridHeader()
        {
            return new List<GridColumn<CheckDepot_View>>{
                this.MakeGridHeader(x => x.DepotName_view),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.CDState),
                this.MakeGridHeader(x => x.CDDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<CheckDepot_View> GetSearchQuery()
        {
            var query = DC.Set<CheckDepot>()
                .CheckEqual(Searcher.DepotsID, x=>x.DepotsID)
                .CheckEqual(Searcher.FrameworkUserID, x=>x.FrameworkUserID)
                .CheckEqual(Searcher.CDState, x=>x.CDState)
                .Select(x => new CheckDepot_View
                {
				    ID = x.ID,
                    DepotName_view = x.Depots.DepotName,
                    Name_view = x.FrameworkUser.Name,
                    CDState = x.CDState,
                    CDDesc = x.CDDesc,
                    CreateTime = x.CreateTime,
                })
                .OrderByDescending(x => x.CreateTime);
            return query;
        }

    }

    public class CheckDepot_View : CheckDepot{
        [Display(Name = "仓库名称")]
        public String DepotName_view { get; set; }
        [Display(Name = "_Admin.Name")]
        public String Name_view { get; set; }

    }
}
