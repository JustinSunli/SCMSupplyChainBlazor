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
    public partial class ProductTypesBatchVM : BaseBatchVM<ProductTypes, ProductTypes_BatchEdit>
    {
        public ProductTypesBatchVM()
        {
            ListVM = new ProductTypesListVM();
            LinkedVM = new ProductTypes_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProductTypes_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
