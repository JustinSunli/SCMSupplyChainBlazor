using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.Inventory.PayOffsVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class PayOffsApiTest
    {
        private PayOffsController _controller;
        private string _seed;

        public PayOffsApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PayOffsController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new PayOffsSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PayOffsVM vm = _controller.Wtm.CreateVM<PayOffsVM>();
            PayOffs v = new PayOffs();
            
            v.POID = "DKeQ4";
            v.DepotsID = AddDepots();
            v.POState = SCMSupplyChain.Model.POState.未定义2;
            v.PODesc = "yRry5";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PayOffs>().Find(v.ID);
                
                Assert.AreEqual(data.POID, "DKeQ4");
                Assert.AreEqual(data.POState, SCMSupplyChain.Model.POState.未定义2);
                Assert.AreEqual(data.PODesc, "yRry5");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            PayOffs v = new PayOffs();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.POID = "DKeQ4";
                v.DepotsID = AddDepots();
                v.POState = SCMSupplyChain.Model.POState.未定义2;
                v.PODesc = "yRry5";
                context.Set<PayOffs>().Add(v);
                context.SaveChanges();
            }

            PayOffsVM vm = _controller.Wtm.CreateVM<PayOffsVM>();
            var oldID = v.ID;
            v = new PayOffs();
            v.ID = oldID;
       		
            v.POID = "LghBP";
            v.POState = SCMSupplyChain.Model.POState.未定义1;
            v.PODesc = "3G9eQ";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.POID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.POState", "");
            vm.FC.Add("Entity.PODesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PayOffs>().Find(v.ID);
 				
                Assert.AreEqual(data.POID, "LghBP");
                Assert.AreEqual(data.POState, SCMSupplyChain.Model.POState.未定义1);
                Assert.AreEqual(data.PODesc, "3G9eQ");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            PayOffs v = new PayOffs();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.POID = "DKeQ4";
                v.DepotsID = AddDepots();
                v.POState = SCMSupplyChain.Model.POState.未定义2;
                v.PODesc = "yRry5";
                context.Set<PayOffs>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PayOffs v1 = new PayOffs();
            PayOffs v2 = new PayOffs();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.POID = "DKeQ4";
                v1.DepotsID = AddDepots();
                v1.POState = SCMSupplyChain.Model.POState.未定义2;
                v1.PODesc = "yRry5";
                v2.POID = "LghBP";
                v2.DepotsID = v1.DepotsID; 
                v2.POState = SCMSupplyChain.Model.POState.未定义1;
                v2.PODesc = "3G9eQ";
                context.Set<PayOffs>().Add(v1);
                context.Set<PayOffs>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<PayOffs>().Find(v1.ID);
                var data2 = context.Set<PayOffs>().Find(v2.ID);
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

                v.DepotName = "tQ0WHMMZ";
                v.DepotMan = "23yzRGK";
                v.DepotTelephone = "gkR";
                v.DepotAddress = "6nDbwQ";
                v.DepotDesc = "HDhbP1";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
