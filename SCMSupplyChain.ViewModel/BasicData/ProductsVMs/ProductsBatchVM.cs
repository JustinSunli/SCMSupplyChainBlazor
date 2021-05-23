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
    public partial class ProductsBatchVM : BaseBatchVM<Products, Products_BatchEdit>
    {
        public ProductsBatchVM()
        {
            ListVM = new ProductsListVM();
            LinkedVM = new Products_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Products_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
