using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.SaleReturnVMs
{
    public partial class SaleReturnTemplateVM : BaseTemplateVM
    {
        [Display(Name = "销售退货单号")]
        public ExcelPropety SRID_Excel = ExcelPropety.CreateProperty<SaleReturn>(x => x.SRID);
        [Display(Name = "客户")]
        public ExcelPropety Customers_Excel = ExcelPropety.CreateProperty<SaleReturn>(x => x.CustomersID);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<SaleReturn>(x => x.DepotsID);
        [Display(Name = "状态")]
        public ExcelPropety SRState_Excel = ExcelPropety.CreateProperty<SaleReturn>(x => x.SRState);
        [Display(Name = "备注")]
        public ExcelPropety SRDesc_Excel = ExcelPropety.CreateProperty<SaleReturn>(x => x.SRDesc);

	    protected override void InitVM()
        {
            Customers_Excel.DataType = ColumnDataType.ComboBox;
            Customers_Excel.ListItems = DC.Set<Customers>().GetSelectListItems(Wtm, y => y.CusName);
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class SaleReturnImportVM : BaseImportVM<SaleReturnTemplateVM, SaleReturn>
    {

    }

}
