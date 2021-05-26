using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.Inventory.DepotStockVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class DepotStockApiTest
    {
        private DepotStockController _controller;
        private string _seed;

        public DepotStockApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<DepotStockController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new DepotStockSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            DepotStockVM vm = _controller.Wtm.CreateVM<DepotStockVM>();
            DepotStock v = new DepotStock();
            
            v.DepotsID = AddDepots();
            v.ProductsID = AddProducts();
            v.DSAmount = 18;
            v.DSPrice = 23;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DepotStock>().Find(v.ID);
                
                Assert.AreEqual(data.DSAmount, 18);
                Assert.AreEqual(data.DSPrice, 23);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            DepotStock v = new DepotStock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DepotsID = AddDepots();
                v.ProductsID = AddProducts();
                v.DSAmount = 18;
                v.DSPrice = 23;
                context.Set<DepotStock>().Add(v);
                context.SaveChanges();
            }

            DepotStockVM vm = _controller.Wtm.CreateVM<DepotStockVM>();
            var oldID = v.ID;
            v = new DepotStock();
            v.ID = oldID;
       		
            v.DSAmount = 10;
            v.DSPrice = 33;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.ProductsID", "");
            vm.FC.Add("Entity.DSAmount", "");
            vm.FC.Add("Entity.DSPrice", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DepotStock>().Find(v.ID);
 				
                Assert.AreEqual(data.DSAmount, 10);
                Assert.AreEqual(data.DSPrice, 33);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            DepotStock v = new DepotStock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DepotsID = AddDepots();
                v.ProductsID = AddProducts();
                v.DSAmount = 18;
                v.DSPrice = 23;
                context.Set<DepotStock>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            DepotStock v1 = new DepotStock();
            DepotStock v2 = new DepotStock();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DepotsID = AddDepots();
                v1.ProductsID = AddProducts();
                v1.DSAmount = 18;
                v1.DSPrice = 23;
                v2.DepotsID = v1.DepotsID; 
                v2.ProductsID = v1.ProductsID; 
                v2.DSAmount = 10;
                v2.DSPrice = 33;
                context.Set<DepotStock>().Add(v1);
                context.Set<DepotStock>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<DepotStock>().Find(v1.ID);
                var data2 = context.Set<DepotStock>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddDepots()
        {
            Depots v = new Depots();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.DepotName = "MygNq9sG";
                v.DepotMan = "OsI06uu";
                v.DepotTelephone = "sfMWINFR";
                v.DepotAddress = "XtEXFu";
                v.DepotDesc = "jTvBR7uDp";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddProductUnit()
        {
            ProductUnit v = new ProductUnit();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.PUName = "Uce67j6f7";
                context.Set<ProductUnit>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddProductTypes()
        {
            ProductTypes v = new ProductTypes();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.PTName = "fyrEp";
                v.PTDes = "F17ZV";
                context.Set<ProductTypes>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "BgLzA";
                v.FileExt = "uAPvSSq";
                v.Path = "ytZIh";
                v.Length = 65;
                v.SaveMode = "Oxo5NB8C";
                v.ExtraInfo = "dIiH";
                v.HandlerInfo = "mGmMqo";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddProducts()
        {
            Products v = new Products();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.ProductUnitID = AddProductUnit();
                v.ProductTypesID = AddProductTypes();
                v.ProMax = 45;
                v.ProMin = 24;
                v.ProdName = "ouvP";
                v.ProWorkShop = "NxnGN18BI";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 89;
                v.ProPrice = 80;
                v.ProDesc = "IlOujbf";
                context.Set<Products>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
