using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductTypesVMs
{
    public partial class ProductTypesTemplateVM : BaseTemplateVM
    {
        [Display(Name = "父级")]
        public ExcelPropety Parent_Excel = ExcelPropety.CreateProperty<ProductTypes>(x => x.ParentId);
        [Display(Name = "名称")]
        public ExcelPropety PTName_Excel = ExcelPropety.CreateProperty<ProductTypes>(x => x.PTName);
        [Display(Name = "描述")]
        public ExcelPropety PTDes_Excel = ExcelPropety.CreateProperty<ProductTypes>(x => x.PTDes);

	    protected override void InitVM()
        {
            Parent_Excel.DataType = ColumnDataType.ComboBox;
            Parent_Excel.ListItems = DC.Set<ProductTypes>().GetSelectListItems(Wtm, y => y.PTName);
        }

    }

    public class ProductTypesImportVM : BaseImportVM<ProductTypesTemplateVM, ProductTypes>
    {

    }

}
