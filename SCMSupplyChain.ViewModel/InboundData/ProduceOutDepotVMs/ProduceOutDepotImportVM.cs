using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.ProduceOutDepotVMs
{
    public partial class ProduceOutDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<ProduceOutDepot>(x => x.DepotsID);
        [Display(Name = "状态")]
        public ExcelPropety PODState_Excel = ExcelPropety.CreateProperty<ProduceOutDepot>(x => x.PODState);
        [Display(Name = "备注")]
        public ExcelPropety PODDesc_Excel = ExcelPropety.CreateProperty<ProduceOutDepot>(x => x.PODDesc);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class ProduceOutDepotImportVM : BaseImportVM<ProduceOutDepotTemplateVM, ProduceOutDepot>
    {

    }

}
