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
    public partial class CustomersSearcher : BaseSearcher
    {
        [Display(Name = "客户名称")]
        public String CusName { get; set; }
        [Display(Name = "客户等级")]
        public CusGrade? CusGrade { get; set; }
        [Display(Name = "公司名称")]
        public String CusCompany { get; set; }

        protected override void InitVM()
        {
        }

    }
}
