using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.Inventory.LostsVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class LostsApiTest
    {
        private LostsController _controller;
        private string _seed;

        public LostsApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<LostsController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new LostsSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            LostsVM vm = _controller.Wtm.CreateVM<LostsVM>();
            Losts v = new Losts();
            
            v.LostID = "sWTrOWsWR";
            v.DepotsID = AddDepots();
            v.LostDesc = "Pzf0KpTYy";
            v.LostState = SCMSupplyChain.Model.LostState.未定义1;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Losts>().Find(v.ID);
                
                Assert.AreEqual(data.LostID, "sWTrOWsWR");
                Assert.AreEqual(data.LostDesc, "Pzf0KpTYy");
                Assert.AreEqual(data.LostState, SCMSupplyChain.Model.LostState.未定义1);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Losts v = new Losts();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.LostID = "sWTrOWsWR";
                v.DepotsID = AddDepots();
                v.LostDesc = "Pzf0KpTYy";
                v.LostState = SCMSupplyChain.Model.LostState.未定义1;
                context.Set<Losts>().Add(v);
                context.SaveChanges();
            }

            LostsVM vm = _controller.Wtm.CreateVM<LostsVM>();
            var oldID = v.ID;
            v = new Losts();
            v.ID = oldID;
       		
            v.LostID = "Gm3F7ECaV";
            v.LostDesc = "6iJgee";
            v.LostState = SCMSupplyChain.Model.LostState.未定义1;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.LostID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.LostDesc", "");
            vm.FC.Add("Entity.LostState", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Losts>().Find(v.ID);
 				
                Assert.AreEqual(data.LostID, "Gm3F7ECaV");
                Assert.AreEqual(data.LostDesc, "6iJgee");
                Assert.AreEqual(data.LostState, SCMSupplyChain.Model.LostState.未定义1);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Losts v = new Losts();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.LostID = "sWTrOWsWR";
                v.DepotsID = AddDepots();
                v.LostDesc = "Pzf0KpTYy";
                v.LostState = SCMSupplyChain.Model.LostState.未定义1;
                context.Set<Losts>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Losts v1 = new Losts();
            Losts v2 = new Losts();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.LostID = "sWTrOWsWR";
                v1.DepotsID = AddDepots();
                v1.LostDesc = "Pzf0KpTYy";
                v1.LostState = SCMSupplyChain.Model.LostState.未定义1;
                v2.LostID = "Gm3F7ECaV";
                v2.DepotsID = v1.DepotsID; 
                v2.LostDesc = "6iJgee";
                v2.LostState = SCMSupplyChain.Model.LostState.未定义1;
                context.Set<Losts>().Add(v1);
                context.Set<Losts>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Losts>().Find(v1.ID);
                var data2 = context.Set<Losts>().Find(v2.ID);
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

                v.DepotName = "ennzBwA7";
                v.DepotMan = "9V8I";
                v.DepotTelephone = "t9iEEiYF";
                v.DepotAddress = "Ml71vBS8";
                v.DepotDesc = "WZsJSS5";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
