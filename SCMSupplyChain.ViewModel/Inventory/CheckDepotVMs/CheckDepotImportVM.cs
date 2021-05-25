using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.CheckDepotVMs
{
    public partial class CheckDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "调出仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<CheckDepot>(x => x.DepotsID);
        [Display(Name = "盘点人")]
        public ExcelPropety FrameworkUser_Excel = ExcelPropety.CreateProperty<CheckDepot>(x => x.FrameworkUserID);
        [Display(Name = "状态")]
        public ExcelPropety CDState_Excel = ExcelPropety.CreateProperty<CheckDepot>(x => x.CDState);
        [Display(Name = "备注")]
        public ExcelPropety CDDesc_Excel = ExcelPropety.CreateProperty<CheckDepot>(x => x.CDDesc);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
            FrameworkUser_Excel.DataType = ColumnDataType.ComboBox;
            FrameworkUser_Excel.ListItems = DC.Set<FrameworkUser>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class CheckDepotImportVM : BaseImportVM<CheckDepotTemplateVM, CheckDepot>
    {

    }

}
