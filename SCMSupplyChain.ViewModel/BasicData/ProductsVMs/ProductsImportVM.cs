using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductsVMs
{
    public partial class ProductsTemplateVM : BaseTemplateVM
    {
        [Display(Name = "商品规格")]
        public ExcelPropety ProductUnit_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProductUnitID);
        [Display(Name = "商品类别")]
        public ExcelPropety ProductTypes_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProductTypesID);
        [Display(Name = "库存上限")]
        public ExcelPropety ProMax_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProMax);
        [Display(Name = "库存下限")]
        public ExcelPropety ProMin_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProMin);
        [Display(Name = "商品名称")]
        public ExcelPropety ProdName_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProdName);
        [Display(Name = "生产厂家")]
        public ExcelPropety ProWorkShop_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProWorkShop);
        [Display(Name = "预设进价")]
        public ExcelPropety ProInPrice_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProInPrice);
        [Display(Name = "售价")]
        public ExcelPropety ProPrice_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProPrice);

	    protected override void InitVM()
        {
            ProductUnit_Excel.DataType = ColumnDataType.ComboBox;
            ProductUnit_Excel.ListItems = DC.Set<ProductUnit>().GetSelectListItems(Wtm, y => y.PUName);
            ProductTypes_Excel.DataType = ColumnDataType.ComboBox;
            ProductTypes_Excel.ListItems = DC.Set<ProductTypes>().GetSelectListItems(Wtm, y => y.PTName);
        }

    }

    public class ProductsImportVM : BaseImportVM<ProductsTemplateVM, Products>
    {

    }

}
