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
    public partial class ProductTypesSearcher : BaseSearcher
    {
        [Display(Name = "父级")]
        public Guid? ParentId { get; set; }
        [Display(Name = "名称")]
        public String PTName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
