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
    public partial class ProductUnitBatchVM : BaseBatchVM<ProductUnit, ProductUnit_BatchEdit>
    {
        public ProductUnitBatchVM()
        {
            ListVM = new ProductUnitListVM();
            LinkedVM = new ProductUnit_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ProductUnit_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
