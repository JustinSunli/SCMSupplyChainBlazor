using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.StockInDepotVMs
{
    public partial class StockInDepotSearcher : BaseSearcher
    {
        [Display(Name = "供货商")]
        public Guid? ProductLendID { get; set; }
        [Display(Name = "仓库")]
        public Guid? DepotsID { get; set; }
        [Display(Name = "采购单号")]
        public Guid? StocksID { get; set; }
        [Display(Name = "收货时间")]
        public DateRange SIDDate { get; set; }

        protected override void InitVM()
        {
        }

    }
}
