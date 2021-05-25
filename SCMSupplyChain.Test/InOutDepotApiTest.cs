using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.OutboundData.InOutDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class InOutDepotApiTest
    {
        private InOutDepotController _controller;
        private string _seed;

        public InOutDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<InOutDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new InOutDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            InOutDepotVM vm = _controller.Wtm.CreateVM<InOutDepotVM>();
            InOutDepot v = new InOutDepot();
            
            v.IODID = "M5DrJo0E";
            v.IODType = SCMSupplyChain.Model.IODType.出库;
            v.DepotsID = AddDepots();
            v.IODDesc = "hkLS0";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<InOutDepot>().Find(v.ID);
                
                Assert.AreEqual(data.IODID, "M5DrJo0E");
                Assert.AreEqual(data.IODType, SCMSupplyChain.Model.IODType.出库);
                Assert.AreEqual(data.IODDesc, "hkLS0");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            InOutDepot v = new InOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.IODID = "M5DrJo0E";
                v.IODType = SCMSupplyChain.Model.IODType.出库;
                v.DepotsID = AddDepots();
                v.IODDesc = "hkLS0";
                context.Set<InOutDepot>().Add(v);
                context.SaveChanges();
            }

            InOutDepotVM vm = _controller.Wtm.CreateVM<InOutDepotVM>();
            var oldID = v.ID;
            v = new InOutDepot();
            v.ID = oldID;
       		
            v.IODID = "vZ3";
            v.IODType = SCMSupplyChain.Model.IODType.入库;
            v.IODDesc = "jC0Ed1aTh";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.IODID", "");
            vm.FC.Add("Entity.IODType", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.IODDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<InOutDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.IODID, "vZ3");
                Assert.AreEqual(data.IODType, SCMSupplyChain.Model.IODType.入库);
                Assert.AreEqual(data.IODDesc, "jC0Ed1aTh");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            InOutDepot v = new InOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.IODID = "M5DrJo0E";
                v.IODType = SCMSupplyChain.Model.IODType.出库;
                v.DepotsID = AddDepots();
                v.IODDesc = "hkLS0";
                context.Set<InOutDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            InOutDepot v1 = new InOutDepot();
            InOutDepot v2 = new InOutDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.IODID = "M5DrJo0E";
                v1.IODType = SCMSupplyChain.Model.IODType.出库;
                v1.DepotsID = AddDepots();
                v1.IODDesc = "hkLS0";
                v2.IODID = "vZ3";
                v2.IODType = SCMSupplyChain.Model.IODType.入库;
                v2.DepotsID = v1.DepotsID; 
                v2.IODDesc = "jC0Ed1aTh";
                context.Set<InOutDepot>().Add(v1);
                context.Set<InOutDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<InOutDepot>().Find(v1.ID);
                var data2 = context.Set<InOutDepot>().Find(v2.ID);
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

                v.DepotName = "JAMQ4iQi6";
                v.DepotMan = "8XcVi";
                v.DepotTelephone = "cw4";
                v.DepotAddress = "zGffZrL1";
                v.DepotDesc = "cSlLR";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
