using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.OtherInDepotVMs
{
    public partial class OtherInDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "其它入库单号")]
        public ExcelPropety OIDID_Excel = ExcelPropety.CreateProperty<OtherInDepot>(x => x.OIDID);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<OtherInDepot>(x => x.DepotsID);
        [Display(Name = "审核状态")]
        public ExcelPropety OIDState_Excel = ExcelPropety.CreateProperty<OtherInDepot>(x => x.OIDState);
        [Display(Name = "备注")]
        public ExcelPropety OIDDesc_Excel = ExcelPropety.CreateProperty<OtherInDepot>(x => x.OIDDesc);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class OtherInDepotImportVM : BaseImportVM<OtherInDepotTemplateVM, OtherInDepot>
    {

    }

}
