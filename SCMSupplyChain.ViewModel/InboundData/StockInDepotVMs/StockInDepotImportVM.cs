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
    public partial class StockInDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "采购入库单号")]
        public ExcelPropety SIDID_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.SIDID);
        [Display(Name = "供货商")]
        public ExcelPropety ProductLend_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.ProductLendID);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.DepotsID);
        [Display(Name = "采购单号")]
        public ExcelPropety Stocks_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.StocksID);
        [Display(Name = "收货时间")]
        public ExcelPropety SIDDate_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.SIDDate);
        [Display(Name = "送货单号")]
        public ExcelPropety SIDDeliver_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.SIDDeliver);
        [Display(Name = "运费")]
        public ExcelPropety SIDFreight_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.SIDFreight);
        [Display(Name = "审核状态")]
        public ExcelPropety SIDData_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.SIDData);
        [Display(Name = "备注")]
        public ExcelPropety SIDDesc_Excel = ExcelPropety.CreateProperty<StockInDepot>(x => x.SIDDesc);

	    protected override void InitVM()
        {
            ProductLend_Excel.DataType = ColumnDataType.ComboBox;
            ProductLend_Excel.ListItems = DC.Set<ProductLend>().GetSelectListItems(Wtm, y => y.PPName);
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
            Stocks_Excel.DataType = ColumnDataType.ComboBox;
            Stocks_Excel.ListItems = DC.Set<Stocks>().GetSelectListItems(Wtm, y => y.StockID);
        }

    }

    public class StockInDepotImportVM : BaseImportVM<StockInDepotTemplateVM, StockInDepot>
    {

    }

}
