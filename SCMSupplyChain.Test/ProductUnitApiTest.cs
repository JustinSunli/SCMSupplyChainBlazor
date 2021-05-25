using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.BasicData.ProductUnitVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class ProductUnitApiTest
    {
        private ProductUnitController _controller;
        private string _seed;

        public ProductUnitApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProductUnitController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProductUnitSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProductUnitVM vm = _controller.Wtm.CreateVM<ProductUnitVM>();
            ProductUnit v = new ProductUnit();
            
            v.PUName = "4PBK";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductUnit>().Find(v.ID);
                
                Assert.AreEqual(data.PUName, "4PBK");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProductUnit v = new ProductUnit();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.PUName = "4PBK";
                context.Set<ProductUnit>().Add(v);
                context.SaveChanges();
            }

            ProductUnitVM vm = _controller.Wtm.CreateVM<ProductUnitVM>();
            var oldID = v.ID;
            v = new ProductUnit();
            v.ID = oldID;
       		
            v.PUName = "Fwgq";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.PUName", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductUnit>().Find(v.ID);
 				
                Assert.AreEqual(data.PUName, "Fwgq");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProductUnit v = new ProductUnit();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.PUName = "4PBK";
                context.Set<ProductUnit>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProductUnit v1 = new ProductUnit();
            ProductUnit v2 = new ProductUnit();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.PUName = "4PBK";
                v2.PUName = "Fwgq";
                context.Set<ProductUnit>().Add(v1);
                context.Set<ProductUnit>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProductUnit>().Find(v1.ID);
                var data2 = context.Set<ProductUnit>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
