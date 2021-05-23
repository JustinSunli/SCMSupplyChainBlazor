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
    public partial class ProductLendSearcher : BaseSearcher
    {
        [Display(Name = "供货商名称")]
        public String PPName { get; set; }
        [Display(Name = "公司名称")]
        public String PPCompany { get; set; }
        [Display(Name = "银行名称")]
        public String PPBank { get; set; }

        protected override void InitVM()
        {
        }

    }
}
