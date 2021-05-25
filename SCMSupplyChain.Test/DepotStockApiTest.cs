using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.InboundData.DepotStockVMs;
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
            v.DSAmount = 1;
            v.DSPrice = 49;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DepotStock>().Find(v.ID);
                
                Assert.AreEqual(data.DSAmount, 1);
                Assert.AreEqual(data.DSPrice, 49);
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
                v.DSAmount = 1;
                v.DSPrice = 49;
                context.Set<DepotStock>().Add(v);
                context.SaveChanges();
            }

            DepotStockVM vm = _controller.Wtm.CreateVM<DepotStockVM>();
            var oldID = v.ID;
            v = new DepotStock();
            v.ID = oldID;
       		
            v.DSAmount = 80;
            v.DSPrice = 4;
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
 				
                Assert.AreEqual(data.DSAmount, 80);
                Assert.AreEqual(data.DSPrice, 4);
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
                v.DSAmount = 1;
                v.DSPrice = 49;
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
                v1.DSAmount = 1;
                v1.DSPrice = 49;
                v2.DepotsID = v1.DepotsID; 
                v2.ProductsID = v1.ProductsID; 
                v2.DSAmount = 80;
                v2.DSPrice = 4;
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

                v.DepotName = "CJJYMw";
                v.DepotMan = "4jO";
                v.DepotTelephone = "uHuLEA";
                v.DepotAddress = "xp0qho";
                v.DepotDesc = "UVJX8f";
                context.Set<Depots>().Add(v);
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

                v.FileName = "SBplODwI0";
                v.FileExt = "rb2gG828Y";
                v.Path = "GBYXE";
                v.Length = 11;
                v.SaveMode = "Ma0N";
                v.ExtraInfo = "bU9Wui";
                v.HandlerInfo = "Yjwh0";
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

                v.ProMax = 16;
                v.ProMin = 40;
                v.ProdName = "vhTo4X";
                v.ProWorkShop = "Ywbc";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 1;
                v.ProPrice = 26;
                v.ProDesc = "7Xet";
                context.Set<Products>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
