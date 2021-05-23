using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.DepotsVMs
{
    public partial class DepotsTemplateVM : BaseTemplateVM
    {
        [Display(Name = "仓库名称")]
        public ExcelPropety DepotName_Excel = ExcelPropety.CreateProperty<Depots>(x => x.DepotName);
        [Display(Name = "联系人")]
        public ExcelPropety DepotMan_Excel = ExcelPropety.CreateProperty<Depots>(x => x.DepotMan);
        [Display(Name = "联系电话")]
        public ExcelPropety DepotTelephone_Excel = ExcelPropety.CreateProperty<Depots>(x => x.DepotTelephone);
        [Display(Name = "仓库地址")]
        public ExcelPropety DepotAddress_Excel = ExcelPropety.CreateProperty<Depots>(x => x.DepotAddress);
        [Display(Name = "备注")]
        public ExcelPropety DepotDesc_Excel = ExcelPropety.CreateProperty<Depots>(x => x.DepotDesc);

	    protected override void InitVM()
        {
        }

    }

    public class DepotsImportVM : BaseImportVM<DepotsTemplateVM, Depots>
    {

    }

}
