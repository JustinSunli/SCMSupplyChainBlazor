using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SCMSupplyChain.Model;


namespace SCMSupplyChain.ViewModel.BasicData.ProductsVMs
{
    public partial class ProductsListVM : BasePagedListVM<Products_View, ProductsSearcher>
    {

        protected override IEnumerable<IGridColumn<Products_View>> InitGridHeader()
        {
            return new List<GridColumn<Products_View>>{
                this.MakeGridHeader(x => x.ProMax),
                this.MakeGridHeader(x => x.ProMin),
                this.MakeGridHeader(x => x.ProdName),
                this.MakeGridHeader(x => x.ProWorkShop),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.ProInPrice),
                this.MakeGridHeader(x => x.ProPrice),
                this.MakeGridHeader(x => x.ProDesc),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(Products_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<Products_View> GetSearchQuery()
        {
            var query = DC.Set<Products>()
                .CheckContain(Searcher.ProdName, x=>x.ProdName)
                .CheckContain(Searcher.ProWorkShop, x=>x.ProWorkShop)
                .Select(x => new Products_View
                {
				    ID = x.ID,
                    ProMax = x.ProMax,
                    ProMin = x.ProMin,
                    ProdName = x.ProdName,
                    ProWorkShop = x.ProWorkShop,
                    PhotoId = x.PhotoId,
                    ProInPrice = x.ProInPrice,
                    ProPrice = x.ProPrice,
                    ProDesc = x.ProDesc,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Products_View : Products{

    }
}
