using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.SaleDepotVMs
{
    public partial class SaleDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "销售出库单号")]
        public ExcelPropety SDID_Excel = ExcelPropety.CreateProperty<SaleDepot>(x => x.SDID);
        [Display(Name = "客户")]
        public ExcelPropety Customers_Excel = ExcelPropety.CreateProperty<SaleDepot>(x => x.CustomersID);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<SaleDepot>(x => x.DepotsID);
        [Display(Name = "状态")]
        public ExcelPropety SDState_Excel = ExcelPropety.CreateProperty<SaleDepot>(x => x.SDState);
        [Display(Name = "备注")]
        public ExcelPropety SDDesc_Excel = ExcelPropety.CreateProperty<SaleDepot>(x => x.SDDesc);

	    protected override void InitVM()
        {
            Customers_Excel.DataType = ColumnDataType.ComboBox;
            Customers_Excel.ListItems = DC.Set<Customers>().GetSelectListItems(Wtm, y => y.CusName);
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class SaleDepotImportVM : BaseImportVM<SaleDepotTemplateVM, SaleDepot>
    {

    }

}
