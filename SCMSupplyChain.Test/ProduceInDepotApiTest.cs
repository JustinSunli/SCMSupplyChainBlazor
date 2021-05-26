using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.InboundData.ProduceInDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class ProduceInDepotApiTest
    {
        private ProduceInDepotController _controller;
        private string _seed;

        public ProduceInDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProduceInDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProduceInDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProduceInDepotVM vm = _controller.Wtm.CreateVM<ProduceInDepotVM>();
            ProduceInDepot v = new ProduceInDepot();
            
            v.PIDID = "6fHSzIjA";
            v.DepotsID = AddDepots();
            v.PIDState = SCMSupplyChain.Model.PIDState.未定义1;
            v.PDIDesc = "KQOGlnR0";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProduceInDepot>().Find(v.ID);
                
                Assert.AreEqual(data.PIDID, "6fHSzIjA");
                Assert.AreEqual(data.PIDState, SCMSupplyChain.Model.PIDState.未定义1);
                Assert.AreEqual(data.PDIDesc, "KQOGlnR0");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProduceInDepot v = new ProduceInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.PIDID = "6fHSzIjA";
                v.DepotsID = AddDepots();
                v.PIDState = SCMSupplyChain.Model.PIDState.未定义1;
                v.PDIDesc = "KQOGlnR0";
                context.Set<ProduceInDepot>().Add(v);
                context.SaveChanges();
            }

            ProduceInDepotVM vm = _controller.Wtm.CreateVM<ProduceInDepotVM>();
            var oldID = v.ID;
            v = new ProduceInDepot();
            v.ID = oldID;
       		
            v.PIDID = "LPTRCp";
            v.PIDState = SCMSupplyChain.Model.PIDState.未定义3;
            v.PDIDesc = "PF6Ie2";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.PIDID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.PIDState", "");
            vm.FC.Add("Entity.PDIDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProduceInDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.PIDID, "LPTRCp");
                Assert.AreEqual(data.PIDState, SCMSupplyChain.Model.PIDState.未定义3);
                Assert.AreEqual(data.PDIDesc, "PF6Ie2");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProduceInDepot v = new ProduceInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.PIDID = "6fHSzIjA";
                v.DepotsID = AddDepots();
                v.PIDState = SCMSupplyChain.Model.PIDState.未定义1;
                v.PDIDesc = "KQOGlnR0";
                context.Set<ProduceInDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProduceInDepot v1 = new ProduceInDepot();
            ProduceInDepot v2 = new ProduceInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.PIDID = "6fHSzIjA";
                v1.DepotsID = AddDepots();
                v1.PIDState = SCMSupplyChain.Model.PIDState.未定义1;
                v1.PDIDesc = "KQOGlnR0";
                v2.PIDID = "LPTRCp";
                v2.DepotsID = v1.DepotsID; 
                v2.PIDState = SCMSupplyChain.Model.PIDState.未定义3;
                v2.PDIDesc = "PF6Ie2";
                context.Set<ProduceInDepot>().Add(v1);
                context.Set<ProduceInDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProduceInDepot>().Find(v1.ID);
                var data2 = context.Set<ProduceInDepot>().Find(v2.ID);
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

                v.DepotName = "MjARZNj";
                v.DepotMan = "3U0v";
                v.DepotTelephone = "JL9";
                v.DepotAddress = "Aw0a";
                v.DepotDesc = "rVUBM";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
