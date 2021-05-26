using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.BasicData.DepotsVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass] 
    public class DepotsApiTest
    {
        private DepotsController _controller; 

        private string _seed;

        public DepotsApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<DepotsController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new DepotsSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            DepotsVM vm = _controller.Wtm.CreateVM<DepotsVM>();
            Depots v = new Depots();
            
            v.DepotName = "bNyT";
            v.DepotMan = "26XU";
            v.DepotTelephone = "b4JNkCO";
            v.DepotAddress = "MNM";
            v.DepotDesc = "DV0N";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Depots>().Find(v.ID);
                
                Assert.AreEqual(data.DepotName, "bNyT");
                Assert.AreEqual(data.DepotMan, "26XU");
                Assert.AreEqual(data.DepotTelephone, "b4JNkCO");
                Assert.AreEqual(data.DepotAddress, "MNM");
                Assert.AreEqual(data.DepotDesc, "DV0N");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Depots v = new Depots();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DepotName = "bNyT";
                v.DepotMan = "26XU";
                v.DepotTelephone = "b4JNkCO";
                v.DepotAddress = "MNM";
                v.DepotDesc = "DV0N";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
            }

            DepotsVM vm = _controller.Wtm.CreateVM<DepotsVM>();
            var oldID = v.ID;
            v = new Depots();
            v.ID = oldID;
       		
            v.DepotName = "FxQ7";
            v.DepotMan = "3neBp";
            v.DepotTelephone = "NevvfAW";
            v.DepotAddress = "pjAab";
            v.DepotDesc = "yaPjFw";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DepotName", "");
            vm.FC.Add("Entity.DepotMan", "");
            vm.FC.Add("Entity.DepotTelephone", "");
            vm.FC.Add("Entity.DepotAddress", "");
            vm.FC.Add("Entity.DepotDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Depots>().Find(v.ID);
 				
                Assert.AreEqual(data.DepotName, "FxQ7");
                Assert.AreEqual(data.DepotMan, "3neBp");
                Assert.AreEqual(data.DepotTelephone, "NevvfAW");
                Assert.AreEqual(data.DepotAddress, "pjAab");
                Assert.AreEqual(data.DepotDesc, "yaPjFw");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Depots v = new Depots();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DepotName = "bNyT";
                v.DepotMan = "26XU";
                v.DepotTelephone = "b4JNkCO";
                v.DepotAddress = "MNM";
                v.DepotDesc = "DV0N";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Depots v1 = new Depots();
            Depots v2 = new Depots();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DepotName = "bNyT";
                v1.DepotMan = "26XU";
                v1.DepotTelephone = "b4JNkCO";
                v1.DepotAddress = "MNM";
                v1.DepotDesc = "DV0N";
                v2.DepotName = "FxQ7";
                v2.DepotMan = "3neBp";
                v2.DepotTelephone = "NevvfAW";
                v2.DepotAddress = "pjAab";
                v2.DepotDesc = "yaPjFw";
                context.Set<Depots>().Add(v1);
                context.Set<Depots>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Depots>().Find(v1.ID);
                var data2 = context.Set<Depots>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
