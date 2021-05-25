using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.LostsVMs
{
    public partial class LostsTemplateVM : BaseTemplateVM
    {
        [Display(Name = "报损单号")]
        public ExcelPropety LostID_Excel = ExcelPropety.CreateProperty<Losts>(x => x.LostID);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<Losts>(x => x.DepotsID);
        [Display(Name = "备注")]
        public ExcelPropety LostDesc_Excel = ExcelPropety.CreateProperty<Losts>(x => x.LostDesc);
        [Display(Name = "状态")]
        public ExcelPropety LostState_Excel = ExcelPropety.CreateProperty<Losts>(x => x.LostState);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class LostsImportVM : BaseImportVM<LostsTemplateVM, Losts>
    {

    }

}
