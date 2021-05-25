using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.OutboundData.SaleDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class SaleDepotApiTest
    {
        private SaleDepotController _controller;
        private string _seed;

        public SaleDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<SaleDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new SaleDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            SaleDepotVM vm = _controller.Wtm.CreateVM<SaleDepotVM>();
            SaleDepot v = new SaleDepot();
            
            v.SDID = "llzttATB";
            v.CustomersID = AddCustomers();
            v.DepotsID = AddDepots();
            v.SDState = SCMSupplyChain.Model.SDState.未定义3;
            v.SDDesc = "dKnEjDp7L";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SaleDepot>().Find(v.ID);
                
                Assert.AreEqual(data.SDID, "llzttATB");
                Assert.AreEqual(data.SDState, SCMSupplyChain.Model.SDState.未定义3);
                Assert.AreEqual(data.SDDesc, "dKnEjDp7L");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            SaleDepot v = new SaleDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.SDID = "llzttATB";
                v.CustomersID = AddCustomers();
                v.DepotsID = AddDepots();
                v.SDState = SCMSupplyChain.Model.SDState.未定义3;
                v.SDDesc = "dKnEjDp7L";
                context.Set<SaleDepot>().Add(v);
                context.SaveChanges();
            }

            SaleDepotVM vm = _controller.Wtm.CreateVM<SaleDepotVM>();
            var oldID = v.ID;
            v = new SaleDepot();
            v.ID = oldID;
       		
            v.SDID = "7n7mcX";
            v.SDState = SCMSupplyChain.Model.SDState.未定义3;
            v.SDDesc = "U4MY";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SDID", "");
            vm.FC.Add("Entity.CustomersID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.SDState", "");
            vm.FC.Add("Entity.SDDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SaleDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.SDID, "7n7mcX");
                Assert.AreEqual(data.SDState, SCMSupplyChain.Model.SDState.未定义3);
                Assert.AreEqual(data.SDDesc, "U4MY");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            SaleDepot v = new SaleDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.SDID = "llzttATB";
                v.CustomersID = AddCustomers();
                v.DepotsID = AddDepots();
                v.SDState = SCMSupplyChain.Model.SDState.未定义3;
                v.SDDesc = "dKnEjDp7L";
                context.Set<SaleDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            SaleDepot v1 = new SaleDepot();
            SaleDepot v2 = new SaleDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.SDID = "llzttATB";
                v1.CustomersID = AddCustomers();
                v1.DepotsID = AddDepots();
                v1.SDState = SCMSupplyChain.Model.SDState.未定义3;
                v1.SDDesc = "dKnEjDp7L";
                v2.SDID = "7n7mcX";
                v2.CustomersID = v1.CustomersID; 
                v2.DepotsID = v1.DepotsID; 
                v2.SDState = SCMSupplyChain.Model.SDState.未定义3;
                v2.SDDesc = "U4MY";
                context.Set<SaleDepot>().Add(v1);
                context.Set<SaleDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SaleDepot>().Find(v1.ID);
                var data2 = context.Set<SaleDepot>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddCustomers()
        {
            Customers v = new Customers();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.CusName = "uTh2x";
                v.CusGrade = SCMSupplyChain.Model.CusGrade.VIP4;
                v.CusCompany = "ebQ";
                v.CusMan = "B7u";
                v.CusTelephone = "M5JMHm";
                v.CusDesc = "neRcL";
                context.Set<Customers>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddDepots()
        {
            Depots v = new Depots();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.DepotName = "zBp6msP";
                v.DepotMan = "k2qk3X9n";
                v.DepotTelephone = "Bfcd3qjNI";
                v.DepotAddress = "xos6pqt";
                v.DepotDesc = "nel";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
