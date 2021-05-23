using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductLendVMs
{
    public partial class ProductLendTemplateVM : BaseTemplateVM
    {
        [Display(Name = "供货商名称")]
        public ExcelPropety PPName_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPName);
        [Display(Name = "公司名称")]
        public ExcelPropety PPCompany_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPCompany);
        [Display(Name = "联系人")]
        public ExcelPropety PPMan_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPMan);
        [Display(Name = "联系电话")]
        public ExcelPropety PPTel_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPTel);
        [Display(Name = "地址")]
        public ExcelPropety PPAddress_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPAddress);
        [Display(Name = "传真")]
        public ExcelPropety PPFax_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPFax);
        [Display(Name = "邮箱")]
        public ExcelPropety Email_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.Email);
        [Display(Name = "网址")]
        public ExcelPropety PPUrl_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPUrl);
        [Display(Name = "银行名称")]
        public ExcelPropety PPBank_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPBank);
        [Display(Name = "银行账号")]
        public ExcelPropety PPGoods_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPGoods);
        [Display(Name = "备注")]
        public ExcelPropety PPDesc_Excel = ExcelPropety.CreateProperty<ProductLend>(x => x.PPDesc);

	    protected override void InitVM()
        {
        }

    }

    public class ProductLendImportVM : BaseImportVM<ProductLendTemplateVM, ProductLend>
    {

    }

}
