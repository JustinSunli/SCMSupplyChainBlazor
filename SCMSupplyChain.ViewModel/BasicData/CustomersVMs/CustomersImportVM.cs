using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.CustomersVMs
{
    public partial class CustomersTemplateVM : BaseTemplateVM
    {
        [Display(Name = "客户名称")]
        public ExcelPropety CusName_Excel = ExcelPropety.CreateProperty<Customers>(x => x.CusName);
        [Display(Name = "客户等级")]
        public ExcelPropety CusGrade_Excel = ExcelPropety.CreateProperty<Customers>(x => x.CusGrade);
        [Display(Name = "公司名称")]
        public ExcelPropety CusCompany_Excel = ExcelPropety.CreateProperty<Customers>(x => x.CusCompany);
        [Display(Name = "联系人")]
        public ExcelPropety CusMan_Excel = ExcelPropety.CreateProperty<Customers>(x => x.CusMan);
        [Display(Name = "联系电话")]
        public ExcelPropety CusTelephone_Excel = ExcelPropety.CreateProperty<Customers>(x => x.CusTelephone);
        [Display(Name = "备注")]
        public ExcelPropety CusDesc_Excel = ExcelPropety.CreateProperty<Customers>(x => x.CusDesc);

	    protected override void InitVM()
        {
        }

    }

    public class CustomersImportVM : BaseImportVM<CustomersTemplateVM, Customers>
    {

    }

}
