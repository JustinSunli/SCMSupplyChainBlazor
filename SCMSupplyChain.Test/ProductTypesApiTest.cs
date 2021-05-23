using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.BasicData.ProductTypesVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class ProductTypesApiTest
    {
        private ProductTypesController _controller;
        private string _seed;

        public ProductTypesApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProductTypesController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProductTypesSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProductTypesVM vm = _controller.Wtm.CreateVM<ProductTypesVM>();
            ProductTypes v = new ProductTypes();
            
            v.ParentId = AddProductTypes();
            v.PTName = "m6X";
            v.PTDes = "N4Ly2H";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductTypes>().Find(v.ID);
                
                Assert.AreEqual(data.PTName, "m6X");
                Assert.AreEqual(data.PTDes, "N4Ly2H");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProductTypes v = new ProductTypes();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ParentId = AddProductTypes();
                v.PTName = "m6X";
                v.PTDes = "N4Ly2H";
                context.Set<ProductTypes>().Add(v);
                context.SaveChanges();
            }

            ProductTypesVM vm = _controller.Wtm.CreateVM<ProductTypesVM>();
            var oldID = v.ID;
            v = new ProductTypes();
            v.ID = oldID;
       		
            v.PTName = "Fg9Yr";
            v.PTDes = "1l4oc3fIo";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ParentId", "");
            vm.FC.Add("Entity.PTName", "");
            vm.FC.Add("Entity.PTDes", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductTypes>().Find(v.ID);
 				
                Assert.AreEqual(data.PTName, "Fg9Yr");
                Assert.AreEqual(data.PTDes, "1l4oc3fIo");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProductTypes v = new ProductTypes();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ParentId = AddProductTypes();
                v.PTName = "m6X";
                v.PTDes = "N4Ly2H";
                context.Set<ProductTypes>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProductTypes v1 = new ProductTypes();
            ProductTypes v2 = new ProductTypes();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ParentId = AddProductTypes();
                v1.PTName = "m6X";
                v1.PTDes = "N4Ly2H";
                v2.ParentId = v1.ParentId; 
                v2.PTName = "Fg9Yr";
                v2.PTDes = "1l4oc3fIo";
                context.Set<ProductTypes>().Add(v1);
                context.Set<ProductTypes>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProductTypes>().Find(v1.ID);
                var data2 = context.Set<ProductTypes>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddProductTypes()
        {
            ProductTypes v = new ProductTypes();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.PTName = "sztj";
                v.PTDes = "zf3AibqV";
                context.Set<ProductTypes>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
