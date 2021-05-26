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
            
            v.PIDID = "aFNF";
            v.DepotsID = AddDepots();
            v.PDIDesc = "jrZrcN";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProduceInDepot>().Find(v.ID);
                
                Assert.AreEqual(data.PIDID, "aFNF");
                Assert.AreEqual(data.PDIDesc, "jrZrcN");
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
       			
                v.PIDID = "aFNF";
                v.DepotsID = AddDepots();
                v.PDIDesc = "jrZrcN";
                context.Set<ProduceInDepot>().Add(v);
                context.SaveChanges();
            }

            ProduceInDepotVM vm = _controller.Wtm.CreateVM<ProduceInDepotVM>();
            var oldID = v.ID;
            v = new ProduceInDepot();
            v.ID = oldID;
       		
            v.PIDID = "f3Ukgjgz4";
            v.PDIDesc = "34Z";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.PIDID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.PDIDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProduceInDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.PIDID, "f3Ukgjgz4");
                Assert.AreEqual(data.PDIDesc, "34Z");
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
        		
                v.PIDID = "aFNF";
                v.DepotsID = AddDepots();
                v.PDIDesc = "jrZrcN";
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
				
                v1.PIDID = "aFNF";
                v1.DepotsID = AddDepots();
                v1.PDIDesc = "jrZrcN";
                v2.PIDID = "f3Ukgjgz4";
                v2.DepotsID = v1.DepotsID; 
                v2.PDIDesc = "34Z";
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

                v.DepotName = "YgspAGX";
                v.DepotMan = "nn5jbz";
                v.DepotTelephone = "ZQYGjNb";
                v.DepotAddress = "XuX";
                v.DepotDesc = "Wd5";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
