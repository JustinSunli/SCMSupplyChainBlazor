using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.Inventory.PayOffsVMs
{
    public partial class PayOffsTemplateVM : BaseTemplateVM
    {
        [Display(Name = "报溢单号")]
        public ExcelPropety POID_Excel = ExcelPropety.CreateProperty<PayOffs>(x => x.POID);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<PayOffs>(x => x.DepotsID);
        [Display(Name = "状态")]
        public ExcelPropety POState_Excel = ExcelPropety.CreateProperty<PayOffs>(x => x.POState);
        [Display(Name = "备注")]
        public ExcelPropety PODesc_Excel = ExcelPropety.CreateProperty<PayOffs>(x => x.PODesc);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class PayOffsImportVM : BaseImportVM<PayOffsTemplateVM, PayOffs>
    {

    }

}
