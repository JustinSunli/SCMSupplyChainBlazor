using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.DepotStockVMs
{
    public partial class DepotStockSearcher : BaseSearcher
    {
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "库存数量")]
        public Int32? DSAmount { get; set; }

        protected override void InitVM()
        {
        }

    }
}
