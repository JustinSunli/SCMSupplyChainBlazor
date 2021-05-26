using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.Model
{
    [Display(Name = "商品类别")]
    public class ProductTypes : PersistPoco
    {

        public List<ProductTypes> Children { get; set; }
        [Display(Name = "父级")]
        public ProductTypes Parent { get; set; }
        [Display(Name = "父级")]
        public Guid? ParentId { get; set; }

        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(200,ErrorMessage = "{0}超过最长限制,200内")]
        public string PTName { get; set; }

        [Display(Name = "描述")]
        [StringLength(200, ErrorMessage = "描述超过最长限制,200内")]
        public string PTDes { get; set; }
    }
}
