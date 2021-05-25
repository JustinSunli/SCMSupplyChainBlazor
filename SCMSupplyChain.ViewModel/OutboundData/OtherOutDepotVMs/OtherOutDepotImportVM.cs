using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.OtherOutDepotVMs
{
    public partial class OtherOutDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "其他出库单号")]
        public ExcelPropety OODID_Excel = ExcelPropety.CreateProperty<OtherOutDepot>(x => x.OODID);
        [Display(Name = "状态")]
        public ExcelPropety OODState_Excel = ExcelPropety.CreateProperty<OtherOutDepot>(x => x.OODState);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<OtherOutDepot>(x => x.DepotsID);
        [Display(Name = "备注")]
        public ExcelPropety OODDesc_Excel = ExcelPropety.CreateProperty<OtherOutDepot>(x => x.OODDesc);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class OtherOutDepotImportVM : BaseImportVM<OtherOutDepotTemplateVM, OtherOutDepot>
    {

    }

}
