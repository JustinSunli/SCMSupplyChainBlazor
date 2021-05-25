using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.OutboundData.InOutDepotVMs
{
    public partial class InOutDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "出库记录号")]
        public ExcelPropety IODID_Excel = ExcelPropety.CreateProperty<InOutDepot>(x => x.IODID);
        [Display(Name = "出库类型")]
        public ExcelPropety IODType_Excel = ExcelPropety.CreateProperty<InOutDepot>(x => x.IODType);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<InOutDepot>(x => x.DepotsID);
        [Display(Name = "描述")]
        public ExcelPropety IODDesc_Excel = ExcelPropety.CreateProperty<InOutDepot>(x => x.IODDesc);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class InOutDepotImportVM : BaseImportVM<InOutDepotTemplateVM, InOutDepot>
    {

    }

}
