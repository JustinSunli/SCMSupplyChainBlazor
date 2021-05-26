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
    public partial class DepotStockTemplateVM : BaseTemplateVM
    {
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<DepotStock>(x => x.DepotsID);
        [Display(Name = "商品")]
        public ExcelPropety Products_Excel = ExcelPropety.CreateProperty<DepotStock>(x => x.ProductsID);
        [Display(Name = "库存数量")]
        public ExcelPropety DSAmount_Excel = ExcelPropety.CreateProperty<DepotStock>(x => x.DSAmount);
        [Display(Name = "进价")]
        public ExcelPropety DSPrice_Excel = ExcelPropety.CreateProperty<DepotStock>(x => x.DSPrice);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
            Products_Excel.DataType = ColumnDataType.ComboBox;
            Products_Excel.ListItems = DC.Set<Products>().GetSelectListItems(Wtm, y => y.ProdName);
        }

    }

    public class DepotStockImportVM : BaseImportVM<DepotStockTemplateVM, DepotStock>
    {

    }

}
