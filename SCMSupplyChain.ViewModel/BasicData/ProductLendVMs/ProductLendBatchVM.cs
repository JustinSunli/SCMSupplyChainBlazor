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
    public partial class ProductLendBatchVM : BaseBatchVM<ProductLend, ProductLend_BatchEdit>
    {
        public ProductLendBatchVM()
        {
            ListVM = new ProductLendListVM();
            LinkedVM = new ProductLend_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProductLend_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
