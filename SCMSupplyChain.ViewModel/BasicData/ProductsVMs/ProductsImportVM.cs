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
        [Display(Name = "备注")]
        public ExcelPropety ProDesc_Excel = ExcelPropety.CreateProperty<Products>(x => x.ProDesc);

	    protected override void InitVM()
        {
        }

    }

    public class ProductsImportVM : BaseImportVM<ProductsTemplateVM, Products>
    {

    }

}
