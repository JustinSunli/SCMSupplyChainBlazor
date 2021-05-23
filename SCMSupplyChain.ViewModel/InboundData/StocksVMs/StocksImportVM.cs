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
    public partial class StocksTemplateVM : BaseTemplateVM
    {
        [Display(Name = "采购单号")]
        public ExcelPropety StockID_Excel = ExcelPropety.CreateProperty<Stocks>(x => x.StockID);
        [Display(Name = "供货商")]
        public ExcelPropety ProductLend_Excel = ExcelPropety.CreateProperty<Stocks>(x => x.ProductLendID);
        [Display(Name = "预计交货时间")]
        public ExcelPropety StockInDate_Excel = ExcelPropety.CreateProperty<Stocks>(x => x.StockInDate);
        [Display(Name = "审核状态")]
        public ExcelPropety StockState_Excel = ExcelPropety.CreateProperty<Stocks>(x => x.StockState);
        [Display(Name = "备注")]
        public ExcelPropety StockDesc_Excel = ExcelPropety.CreateProperty<Stocks>(x => x.StockDesc);

	    protected override void InitVM()
        {
            ProductLend_Excel.DataType = ColumnDataType.ComboBox;
            ProductLend_Excel.ListItems = DC.Set<ProductLend>().GetSelectListItems(Wtm, y => y.PPName);
        }

    }

    public class StocksImportVM : BaseImportVM<StocksTemplateVM, Stocks>
    {

    }

}
