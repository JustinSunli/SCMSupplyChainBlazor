using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "出入库记录详情")]
    public class InOutDepotDetail: PersistPoco
    {
        [Display(Name = " 出入库记录单号")]
        public Guid? InOutDepotID { get; set; }
        [Display(Name = " 出入库记录单号")]
        public InOutDepot InOutDepot { get; set; }

        [Display(Name = "商品")]
        public Guid? ProductsID { get; set; }
        [Display(Name = "商品")]
        public Products Products { get; set; }

        [Display(Name ="数量")]
        public int IODDAmount { get; set; }

        [Display(Name ="价格")]
        public double IODDPrice { get; set; }
    }
}
