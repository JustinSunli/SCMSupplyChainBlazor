using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.OutboundData.ProduceOutDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class ProduceOutDepotApiTest
    {
        private ProduceOutDepotController _controller;
        private string _seed;

        public ProduceOutDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProduceOutDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProduceOutDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProduceOutDepotVM vm = _controller.Wtm.CreateVM<ProduceOutDepotVM>();
            ProduceOutDepot v = new ProduceOutDepot();
            
            v.DepotsID = AddDepots();
            v.PODState = SCMSupplyChain.Model.PODState.未定义2;
            v.PODDesc = "lqB1ni8";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProduceOutDepot>().Find(v.ID);
                
                Assert.AreEqual(data.PODState, SCMSupplyChain.Model.PODState.未定义2);
                Assert.AreEqual(data.PODDesc, "lqB1ni8");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProduceOutDepot v = new ProduceOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DepotsID = AddDepots();
                v.PODState = SCMSupplyChain.Model.PODState.未定义2;
                v.PODDesc = "lqB1ni8";
                context.Set<ProduceOutDepot>().Add(v);
                context.SaveChanges();
            }

            ProduceOutDepotVM vm = _controller.Wtm.CreateVM<ProduceOutDepotVM>();
            var oldID = v.ID;
            v = new ProduceOutDepot();
            v.ID = oldID;
       		
            v.PODState = SCMSupplyChain.Model.PODState.未定义3;
            v.PODDesc = "8upF8D";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.PODState", "");
            vm.FC.Add("Entity.PODDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProduceOutDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.PODState, SCMSupplyChain.Model.PODState.未定义3);
                Assert.AreEqual(data.PODDesc, "8upF8D");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProduceOutDepot v = new ProduceOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DepotsID = AddDepots();
                v.PODState = SCMSupplyChain.Model.PODState.未定义2;
                v.PODDesc = "lqB1ni8";
                context.Set<ProduceOutDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProduceOutDepot v1 = new ProduceOutDepot();
            ProduceOutDepot v2 = new ProduceOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DepotsID = AddDepots();
                v1.PODState = SCMSupplyChain.Model.PODState.未定义2;
                v1.PODDesc = "lqB1ni8";
                v2.DepotsID = v1.DepotsID; 
                v2.PODState = SCMSupplyChain.Model.PODState.未定义3;
                v2.PODDesc = "8upF8D";
                context.Set<ProduceOutDepot>().Add(v1);
                context.Set<ProduceOutDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProduceOutDepot>().Find(v1.ID);
                var data2 = context.Set<ProduceOutDepot>().Find(v2.ID);
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

                v.DepotName = "sv0";
                v.DepotMan = "RfIj";
                v.DepotTelephone = "4hHb";
                v.DepotAddress = "1eFM";
                v.DepotDesc = "CjC9";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
