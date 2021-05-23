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
            
            v.ProMax = 87;
            v.ProMin = 98;
            v.ProdName = "vrrctZ0";
            v.ProWorkShop = "2UT2VXD1e";
            v.PhotoId = AddFileAttachment();
            v.ProInPrice = 62;
            v.ProPrice = 59;
            v.ProDesc = "HOelK";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Products>().Find(v.ID);
                
                Assert.AreEqual(data.ProMax, 87);
                Assert.AreEqual(data.ProMin, 98);
                Assert.AreEqual(data.ProdName, "vrrctZ0");
                Assert.AreEqual(data.ProWorkShop, "2UT2VXD1e");
                Assert.AreEqual(data.ProInPrice, 62);
                Assert.AreEqual(data.ProPrice, 59);
                Assert.AreEqual(data.ProDesc, "HOelK");
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
       			
                v.ProMax = 87;
                v.ProMin = 98;
                v.ProdName = "vrrctZ0";
                v.ProWorkShop = "2UT2VXD1e";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 62;
                v.ProPrice = 59;
                v.ProDesc = "HOelK";
                context.Set<Products>().Add(v);
                context.SaveChanges();
            }

            ProductsVM vm = _controller.Wtm.CreateVM<ProductsVM>();
            var oldID = v.ID;
            v = new Products();
            v.ID = oldID;
       		
            v.ProMax = 82;
            v.ProMin = 49;
            v.ProdName = "vV2qJ";
            v.ProWorkShop = "P4LOhH3YW";
            v.ProInPrice = 38;
            v.ProPrice = 16;
            v.ProDesc = "JTqlRysN";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
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
 				
                Assert.AreEqual(data.ProMax, 82);
                Assert.AreEqual(data.ProMin, 49);
                Assert.AreEqual(data.ProdName, "vV2qJ");
                Assert.AreEqual(data.ProWorkShop, "P4LOhH3YW");
                Assert.AreEqual(data.ProInPrice, 38);
                Assert.AreEqual(data.ProPrice, 16);
                Assert.AreEqual(data.ProDesc, "JTqlRysN");
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
        		
                v.ProMax = 87;
                v.ProMin = 98;
                v.ProdName = "vrrctZ0";
                v.ProWorkShop = "2UT2VXD1e";
                v.PhotoId = AddFileAttachment();
                v.ProInPrice = 62;
                v.ProPrice = 59;
                v.ProDesc = "HOelK";
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
				
                v1.ProMax = 87;
                v1.ProMin = 98;
                v1.ProdName = "vrrctZ0";
                v1.ProWorkShop = "2UT2VXD1e";
                v1.PhotoId = AddFileAttachment();
                v1.ProInPrice = 62;
                v1.ProPrice = 59;
                v1.ProDesc = "HOelK";
                v2.ProMax = 82;
                v2.ProMin = 49;
                v2.ProdName = "vV2qJ";
                v2.ProWorkShop = "P4LOhH3YW";
                v2.PhotoId = v1.PhotoId; 
                v2.ProInPrice = 38;
                v2.ProPrice = 16;
                v2.ProDesc = "JTqlRysN";
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

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "j1G";
                v.FileExt = "zRLc27c";
                v.Path = "Qwav7uV";
                v.Length = 67;
                v.SaveMode = "RaHELTMt";
                v.ExtraInfo = "CT6A";
                v.HandlerInfo = "MYI4";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
