using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.DepotsVMs
{
    public partial class DepotsSearcher : BaseSearcher
    {
        [Display(Name = "仓库名称")]
        public String DepotName { get; set; }
        [Display(Name = "联系人")]
        public String DepotMan { get; set; }
        [Display(Name = "仓库地址")]
        public String DepotAddress { get; set; }

        protected override void InitVM()
        {
        }

    }
}
