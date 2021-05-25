using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.InboundData.ProduceInDepotVMs
{
    public partial class ProduceInDepotTemplateVM : BaseTemplateVM
    {
        [Display(Name = "生产入库单号")]
        public ExcelPropety PIDID_Excel = ExcelPropety.CreateProperty<ProduceInDepot>(x => x.PIDID);
        [Display(Name = "仓库")]
        public ExcelPropety Depots_Excel = ExcelPropety.CreateProperty<ProduceInDepot>(x => x.DepotsID);
        [Display(Name = "备注")]
        public ExcelPropety PDIDesc_Excel = ExcelPropety.CreateProperty<ProduceInDepot>(x => x.PDIDesc);

	    protected override void InitVM()
        {
            Depots_Excel.DataType = ColumnDataType.ComboBox;
            Depots_Excel.ListItems = DC.Set<Depots>().GetSelectListItems(Wtm, y => y.DepotName);
        }

    }

    public class ProduceInDepotImportVM : BaseImportVM<ProduceInDepotTemplateVM, ProduceInDepot>
    {

    }

}
