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
    public partial class ProductsSearcher : BaseSearcher
    {
        [Display(Name = "商品名称")]
        public String ProdName { get; set; }
        [Display(Name = "生产厂家")]
        public String ProWorkShop { get; set; }

        protected override void InitVM()
        {
        }

    }
}
