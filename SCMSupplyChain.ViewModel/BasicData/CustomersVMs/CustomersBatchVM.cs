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
    public partial class CustomersBatchVM : BaseBatchVM<Customers, Customers_BatchEdit>
    {
        public CustomersBatchVM()
        {
            ListVM = new CustomersListVM();
            LinkedVM = new Customers_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Customers_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
