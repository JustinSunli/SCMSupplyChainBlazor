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
            v.ProMax = 57;
            v.ProMin = 92;
            v.ProdName = "db4u";
            v.ProWorkShop = "o6d";
            v.PhotoId = AddFileAttachment();
            v.ProInPrice = 64;
            v.ProPrice = 79;
            v.ProDesc = "ven0";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Products>().Find(v.ID);
                
                Assert.AreEqual(data.ProMax, 57);
                Assert.AreEqual(data.ProMin, 92);
                Assert.AreEqual(data.ProdName, "db4u");
                Assert.AreEqual(data.ProWorkShop, "o6d");
                Assert.AreEqual(data.ProInPrice, 64);
                Assert.AreEqual(data.ProPrice, 79);
                Assert.AreEqual(data.ProDesc, "ven0");
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
                v.ProMax = 57;
                v.ProMin = 92;
                v.ProdName = "db4u";
                v.ProWorkShop = "o6d";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 64;
                v.ProPrice = 79;
                v.ProDesc = "ven0";
                context.Set<Products>().Add(v);
                context.SaveChanges();
            }

            ProductsVM vm = _controller.Wtm.CreateVM<ProductsVM>();
            var oldID = v.ID;
            v = new Products();
            v.ID = oldID;
       		
            v.ProMax = 23;
            v.ProMin = 11;
            v.ProdName = "tnxR";
            v.ProWorkShop = "WdlG6jf";
            v.ProInPrice = 94;
            v.ProPrice = 95;
            v.ProDesc = "0hTsBPW";
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
 				
                Assert.AreEqual(data.ProMax, 23);
                Assert.AreEqual(data.ProMin, 11);
                Assert.AreEqual(data.ProdName, "tnxR");
                Assert.AreEqual(data.ProWorkShop, "WdlG6jf");
                Assert.AreEqual(data.ProInPrice, 94);
                Assert.AreEqual(data.ProPrice, 95);
                Assert.AreEqual(data.ProDesc, "0hTsBPW");
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
                v.ProMax = 57;
                v.ProMin = 92;
                v.ProdName = "db4u";
                v.ProWorkShop = "o6d";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 64;
                v.ProPrice = 79;
                v.ProDesc = "ven0";
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
                v1.ProMax = 57;
                v1.ProMin = 92;
                v1.ProdName = "db4u";
                v1.ProWorkShop = "o6d";
                v1.PhotoId = AddFileAttachment();
                v1.ProInPrice = 64;
                v1.ProPrice = 79;
                v1.ProDesc = "ven0";
                v2.ProductUnitID = v1.ProductUnitID; 
                v2.ProductTypesID = v1.ProductTypesID; 
                v2.ProMax = 23;
                v2.ProMin = 11;
                v2.ProdName = "tnxR";
                v2.ProWorkShop = "WdlG6jf";
                v2.PhotoId = v1.PhotoId; 
                v2.ProInPrice = 94;
                v2.ProPrice = 95;
                v2.ProDesc = "0hTsBPW";
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

                v.PUName = "AtT6f0";
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

                v.PTName = "UiEG2";
                v.PTDes = "1RxjQ6";
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

                v.FileName = "WBq";
                v.FileExt = "6smt78ggf";
                v.Path = "jlg";
                v.Length = 12;
                v.SaveMode = "ndkzLQzl";
                v.ExtraInfo = "VuavBb8l0";
                v.HandlerInfo = "bJr";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
