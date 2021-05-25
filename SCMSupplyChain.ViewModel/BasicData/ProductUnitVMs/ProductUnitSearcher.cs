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
    public partial class ProductUnitSearcher : BaseSearcher
    {
        [Display(Name = "单位名称")]
        public String PUName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
