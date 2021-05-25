using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductUnitVMs
{
    public partial class ProductUnitTemplateVM : BaseTemplateVM
    {
        [Display(Name = "单位名称")]
        public ExcelPropety PUName_Excel = ExcelPropety.CreateProperty<ProductUnit>(x => x.PUName);

	    protected override void InitVM()
        {
        }

    }

    public class ProductUnitImportVM : BaseImportVM<ProductUnitTemplateVM, ProductUnit>
    {

    }

}
