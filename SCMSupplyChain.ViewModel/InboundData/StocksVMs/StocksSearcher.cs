using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.StocksVMs
{
    public partial class StocksSearcher : BaseSearcher
    {
        [Display(Name = "采购单号")]
        public String StockID { get; set; }
        [Display(Name = "供货商")]
        public Guid? ProductLendID { get; set; }
        [Display(Name = "预计交货时间")]
        public DateRange StockInDate { get; set; }
        [Display(Name = "审核状态")]
        public StockState? StockState { get; set; }

        protected override void InitVM()
        {
        }

    }
}
