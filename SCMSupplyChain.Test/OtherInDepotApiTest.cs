using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.InboundData.OtherInDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class OtherInDepotApiTest
    {
        private OtherInDepotController _controller;
        private string _seed;

        public OtherInDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<OtherInDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new OtherInDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            OtherInDepotVM vm = _controller.Wtm.CreateVM<OtherInDepotVM>();
            OtherInDepot v = new OtherInDepot();
            
            v.OIDID = "yL1";
            v.DepotsID = AddDepots();
            v.OIDState = SCMSupplyChain.Model.OIDState.未定义3;
            v.OIDDesc = "B78t";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<OtherInDepot>().Find(v.ID);
                
                Assert.AreEqual(data.OIDID, "yL1");
                Assert.AreEqual(data.OIDState, SCMSupplyChain.Model.OIDState.未定义3);
                Assert.AreEqual(data.OIDDesc, "B78t");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            OtherInDepot v = new OtherInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.OIDID = "yL1";
                v.DepotsID = AddDepots();
                v.OIDState = SCMSupplyChain.Model.OIDState.未定义3;
                v.OIDDesc = "B78t";
                context.Set<OtherInDepot>().Add(v);
                context.SaveChanges();
            }

            OtherInDepotVM vm = _controller.Wtm.CreateVM<OtherInDepotVM>();
            var oldID = v.ID;
            v = new OtherInDepot();
            v.ID = oldID;
       		
            v.OIDID = "LBNoMk";
            v.OIDState = SCMSupplyChain.Model.OIDState.未定义2;
            v.OIDDesc = "61VH";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.OIDID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.OIDState", "");
            vm.FC.Add("Entity.OIDDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<OtherInDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.OIDID, "LBNoMk");
                Assert.AreEqual(data.OIDState, SCMSupplyChain.Model.OIDState.未定义2);
                Assert.AreEqual(data.OIDDesc, "61VH");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            OtherInDepot v = new OtherInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.OIDID = "yL1";
                v.DepotsID = AddDepots();
                v.OIDState = SCMSupplyChain.Model.OIDState.未定义3;
                v.OIDDesc = "B78t";
                context.Set<OtherInDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            OtherInDepot v1 = new OtherInDepot();
            OtherInDepot v2 = new OtherInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.OIDID = "yL1";
                v1.DepotsID = AddDepots();
                v1.OIDState = SCMSupplyChain.Model.OIDState.未定义3;
                v1.OIDDesc = "B78t";
                v2.OIDID = "LBNoMk";
                v2.DepotsID = v1.DepotsID; 
                v2.OIDState = SCMSupplyChain.Model.OIDState.未定义2;
                v2.OIDDesc = "61VH";
                context.Set<OtherInDepot>().Add(v1);
                context.Set<OtherInDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<OtherInDepot>().Find(v1.ID);
                var data2 = context.Set<OtherInDepot>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
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

                v.DepotName = "E70LH624";
                v.DepotMan = "ffCXPyMRo";
                v.DepotTelephone = "mRJPG6wGg";
                v.DepotAddress = "R2Xm";
                v.DepotDesc = "YgC8tMaK";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
