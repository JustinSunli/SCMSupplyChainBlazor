using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.OutboundData.OtherOutDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class OtherOutDepotApiTest
    {
        private OtherOutDepotController _controller;
        private string _seed;

        public OtherOutDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<OtherOutDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new OtherOutDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            OtherOutDepotVM vm = _controller.Wtm.CreateVM<OtherOutDepotVM>();
            OtherOutDepot v = new OtherOutDepot();
            
            v.OODID = "fLy";
            v.OODState = SCMSupplyChain.Model.OODState.未定义2;
            v.DepotsID = AddDepots();
            v.OODDesc = "gZElY9o4";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<OtherOutDepot>().Find(v.ID);
                
                Assert.AreEqual(data.OODID, "fLy");
                Assert.AreEqual(data.OODState, SCMSupplyChain.Model.OODState.未定义2);
                Assert.AreEqual(data.OODDesc, "gZElY9o4");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            OtherOutDepot v = new OtherOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.OODID = "fLy";
                v.OODState = SCMSupplyChain.Model.OODState.未定义2;
                v.DepotsID = AddDepots();
                v.OODDesc = "gZElY9o4";
                context.Set<OtherOutDepot>().Add(v);
                context.SaveChanges();
            }

            OtherOutDepotVM vm = _controller.Wtm.CreateVM<OtherOutDepotVM>();
            var oldID = v.ID;
            v = new OtherOutDepot();
            v.ID = oldID;
       		
            v.OODID = "aidQC";
            v.OODState = SCMSupplyChain.Model.OODState.未定义2;
            v.OODDesc = "XNc1E9D";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.OODID", "");
            vm.FC.Add("Entity.OODState", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.OODDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<OtherOutDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.OODID, "aidQC");
                Assert.AreEqual(data.OODState, SCMSupplyChain.Model.OODState.未定义2);
                Assert.AreEqual(data.OODDesc, "XNc1E9D");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            OtherOutDepot v = new OtherOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.OODID = "fLy";
                v.OODState = SCMSupplyChain.Model.OODState.未定义2;
                v.DepotsID = AddDepots();
                v.OODDesc = "gZElY9o4";
                context.Set<OtherOutDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            OtherOutDepot v1 = new OtherOutDepot();
            OtherOutDepot v2 = new OtherOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.OODID = "fLy";
                v1.OODState = SCMSupplyChain.Model.OODState.未定义2;
                v1.DepotsID = AddDepots();
                v1.OODDesc = "gZElY9o4";
                v2.OODID = "aidQC";
                v2.OODState = SCMSupplyChain.Model.OODState.未定义2;
                v2.DepotsID = v1.DepotsID; 
                v2.OODDesc = "XNc1E9D";
                context.Set<OtherOutDepot>().Add(v1);
                context.Set<OtherOutDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<OtherOutDepot>().Find(v1.ID);
                var data2 = context.Set<OtherOutDepot>().Find(v2.ID);
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

                v.DepotName = "rKfTwjocP";
                v.DepotMan = "TueY5";
                v.DepotTelephone = "x9VhM";
                v.DepotAddress = "wObsphM";
                v.DepotDesc = "J5vZYnil";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
