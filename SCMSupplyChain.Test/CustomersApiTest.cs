using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.BasicData.CustomersVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class CustomersApiTest
    {
        private CustomersController _controller;
        private string _seed;

        public CustomersApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<CustomersController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new CustomersSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            CustomersVM vm = _controller.Wtm.CreateVM<CustomersVM>();
            Customers v = new Customers();
            
            v.CusName = "FnN6ZV7";
            v.CusGrade = SCMSupplyChain.Model.CusGrade.VIP1;
            v.CusCompany = "32bio";
            v.CusMan = "B7358aReV";
            v.CusTelephone = "uohl9Ebf";
            v.CusDesc = "FIpOlvhn";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Customers>().Find(v.ID);
                
                Assert.AreEqual(data.CusName, "FnN6ZV7");
                Assert.AreEqual(data.CusGrade, SCMSupplyChain.Model.CusGrade.VIP1);
                Assert.AreEqual(data.CusCompany, "32bio");
                Assert.AreEqual(data.CusMan, "B7358aReV");
                Assert.AreEqual(data.CusTelephone, "uohl9Ebf");
                Assert.AreEqual(data.CusDesc, "FIpOlvhn");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Customers v = new Customers();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.CusName = "FnN6ZV7";
                v.CusGrade = SCMSupplyChain.Model.CusGrade.VIP1;
                v.CusCompany = "32bio";
                v.CusMan = "B7358aReV";
                v.CusTelephone = "uohl9Ebf";
                v.CusDesc = "FIpOlvhn";
                context.Set<Customers>().Add(v);
                context.SaveChanges();
            }

            CustomersVM vm = _controller.Wtm.CreateVM<CustomersVM>();
            var oldID = v.ID;
            v = new Customers();
            v.ID = oldID;
       		
            v.CusName = "3TkrCGcR";
            v.CusGrade = SCMSupplyChain.Model.CusGrade.VIP4;
            v.CusCompany = "hNL3";
            v.CusMan = "ZS4IJLc0";
            v.CusTelephone = "xXR6AgyP";
            v.CusDesc = "R41Wk";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.CusName", "");
            vm.FC.Add("Entity.CusGrade", "");
            vm.FC.Add("Entity.CusCompany", "");
            vm.FC.Add("Entity.CusMan", "");
            vm.FC.Add("Entity.CusTelephone", "");
            vm.FC.Add("Entity.CusDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Customers>().Find(v.ID);
 				
                Assert.AreEqual(data.CusName, "3TkrCGcR");
                Assert.AreEqual(data.CusGrade, SCMSupplyChain.Model.CusGrade.VIP4);
                Assert.AreEqual(data.CusCompany, "hNL3");
                Assert.AreEqual(data.CusMan, "ZS4IJLc0");
                Assert.AreEqual(data.CusTelephone, "xXR6AgyP");
                Assert.AreEqual(data.CusDesc, "R41Wk");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Customers v = new Customers();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.CusName = "FnN6ZV7";
                v.CusGrade = SCMSupplyChain.Model.CusGrade.VIP1;
                v.CusCompany = "32bio";
                v.CusMan = "B7358aReV";
                v.CusTelephone = "uohl9Ebf";
                v.CusDesc = "FIpOlvhn";
                context.Set<Customers>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Customers v1 = new Customers();
            Customers v2 = new Customers();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.CusName = "FnN6ZV7";
                v1.CusGrade = SCMSupplyChain.Model.CusGrade.VIP1;
                v1.CusCompany = "32bio";
                v1.CusMan = "B7358aReV";
                v1.CusTelephone = "uohl9Ebf";
                v1.CusDesc = "FIpOlvhn";
                v2.CusName = "3TkrCGcR";
                v2.CusGrade = SCMSupplyChain.Model.CusGrade.VIP4;
                v2.CusCompany = "hNL3";
                v2.CusMan = "ZS4IJLc0";
                v2.CusTelephone = "xXR6AgyP";
                v2.CusDesc = "R41Wk";
                context.Set<Customers>().Add(v1);
                context.Set<Customers>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Customers>().Find(v1.ID);
                var data2 = context.Set<Customers>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
