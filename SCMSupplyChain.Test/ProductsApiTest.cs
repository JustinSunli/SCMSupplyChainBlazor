using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.BasicData.ProductsVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class ProductsApiTest
    {
        private ProductsController _controller;
        private string _seed;

        public ProductsApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProductsController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProductsSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProductsVM vm = _controller.Wtm.CreateVM<ProductsVM>();
            Products v = new Products();
            
            v.ProductUnitID = AddProductUnit();
            v.ProductTypesID = AddProductTypes();
            v.ProMax = 53;
            v.ProMin = 2;
            v.ProdName = "gbSf";
            v.ProWorkShop = "9GlXezWvb";
            v.PhotoId = AddFileAttachment();
            v.ProInPrice = 73;
            v.ProPrice = 45;
            v.ProDesc = "w3tsLd";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Products>().Find(v.ID);
                
                Assert.AreEqual(data.ProMax, 53);
                Assert.AreEqual(data.ProMin, 2);
                Assert.AreEqual(data.ProdName, "gbSf");
                Assert.AreEqual(data.ProWorkShop, "9GlXezWvb");
                Assert.AreEqual(data.ProInPrice, 73);
                Assert.AreEqual(data.ProPrice, 45);
                Assert.AreEqual(data.ProDesc, "w3tsLd");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Products v = new Products();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ProductUnitID = AddProductUnit();
                v.ProductTypesID = AddProductTypes();
                v.ProMax = 53;
                v.ProMin = 2;
                v.ProdName = "gbSf";
                v.ProWorkShop = "9GlXezWvb";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 73;
                v.ProPrice = 45;
                v.ProDesc = "w3tsLd";
                context.Set<Products>().Add(v);
                context.SaveChanges();
            }

            ProductsVM vm = _controller.Wtm.CreateVM<ProductsVM>();
            var oldID = v.ID;
            v = new Products();
            v.ID = oldID;
       		
            v.ProMax = 59;
            v.ProMin = 88;
            v.ProdName = "u391ba";
            v.ProWorkShop = "58mvDNZJ";
            v.ProInPrice = 43;
            v.ProPrice = 78;
            v.ProDesc = "1L0sOstS";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ProductUnitID", "");
            vm.FC.Add("Entity.ProductTypesID", "");
            vm.FC.Add("Entity.ProMax", "");
            vm.FC.Add("Entity.ProMin", "");
            vm.FC.Add("Entity.ProdName", "");
            vm.FC.Add("Entity.ProWorkShop", "");
            vm.FC.Add("Entity.PhotoId", "");
            vm.FC.Add("Entity.ProInPrice", "");
            vm.FC.Add("Entity.ProPrice", "");
            vm.FC.Add("Entity.ProDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Products>().Find(v.ID);
 				
                Assert.AreEqual(data.ProMax, 59);
                Assert.AreEqual(data.ProMin, 88);
                Assert.AreEqual(data.ProdName, "u391ba");
                Assert.AreEqual(data.ProWorkShop, "58mvDNZJ");
                Assert.AreEqual(data.ProInPrice, 43);
                Assert.AreEqual(data.ProPrice, 78);
                Assert.AreEqual(data.ProDesc, "1L0sOstS");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Products v = new Products();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ProductUnitID = AddProductUnit();
                v.ProductTypesID = AddProductTypes();
                v.ProMax = 53;
                v.ProMin = 2;
                v.ProdName = "gbSf";
                v.ProWorkShop = "9GlXezWvb";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 73;
                v.ProPrice = 45;
                v.ProDesc = "w3tsLd";
                context.Set<Products>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Products v1 = new Products();
            Products v2 = new Products();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ProductUnitID = AddProductUnit();
                v1.ProductTypesID = AddProductTypes();
                v1.ProMax = 53;
                v1.ProMin = 2;
                v1.ProdName = "gbSf";
                v1.ProWorkShop = "9GlXezWvb";
                v1.PhotoId = AddFileAttachment();
                v1.ProInPrice = 73;
                v1.ProPrice = 45;
                v1.ProDesc = "w3tsLd";
                v2.ProductUnitID = v1.ProductUnitID; 
                v2.ProductTypesID = v1.ProductTypesID; 
                v2.ProMax = 59;
                v2.ProMin = 88;
                v2.ProdName = "u391ba";
                v2.ProWorkShop = "58mvDNZJ";
                v2.PhotoId = v1.PhotoId; 
                v2.ProInPrice = 43;
                v2.ProPrice = 78;
                v2.ProDesc = "1L0sOstS";
                context.Set<Products>().Add(v1);
                context.Set<Products>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Products>().Find(v1.ID);
                var data2 = context.Set<Products>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddProductUnit()
        {
            ProductUnit v = new ProductUnit();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.PUName = "CoIHoXae3";
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

                v.PTName = "G0Cf";
                v.PTDes = "xz69W6sPK";
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

                v.FileName = "CrddPpoj";
                v.FileExt = "aGIh";
                v.Path = "XoHo";
                v.Length = 93;
                v.SaveMode = "xDs2nQuoc";
                v.ExtraInfo = "lTsZZJcdZ";
                v.HandlerInfo = "fIGZbFwm";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
