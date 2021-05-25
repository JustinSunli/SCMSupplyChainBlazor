using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.InboundData.SaleReturnVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class SaleReturnApiTest
    {
        private SaleReturnController _controller;
        private string _seed;

        public SaleReturnApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<SaleReturnController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new SaleReturnSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            SaleReturnVM vm = _controller.Wtm.CreateVM<SaleReturnVM>();
            SaleReturn v = new SaleReturn();
            
            v.SRID = "qH2ATmQ";
            v.CustomersID = AddCustomers();
            v.DepotsID = AddDepots();
            v.SRState = SCMSupplyChain.Model.SRState.未定义3;
            v.SRDesc = "jubk";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SaleReturn>().Find(v.ID);
                
                Assert.AreEqual(data.SRID, "qH2ATmQ");
                Assert.AreEqual(data.SRState, SCMSupplyChain.Model.SRState.未定义3);
                Assert.AreEqual(data.SRDesc, "jubk");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            SaleReturn v = new SaleReturn();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.SRID = "qH2ATmQ";
                v.CustomersID = AddCustomers();
                v.DepotsID = AddDepots();
                v.SRState = SCMSupplyChain.Model.SRState.未定义3;
                v.SRDesc = "jubk";
                context.Set<SaleReturn>().Add(v);
                context.SaveChanges();
            }

            SaleReturnVM vm = _controller.Wtm.CreateVM<SaleReturnVM>();
            var oldID = v.ID;
            v = new SaleReturn();
            v.ID = oldID;
       		
            v.SRID = "2Fx2f";
            v.SRState = SCMSupplyChain.Model.SRState.未定义3;
            v.SRDesc = "L62";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SRID", "");
            vm.FC.Add("Entity.CustomersID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.SRState", "");
            vm.FC.Add("Entity.SRDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SaleReturn>().Find(v.ID);
 				
                Assert.AreEqual(data.SRID, "2Fx2f");
                Assert.AreEqual(data.SRState, SCMSupplyChain.Model.SRState.未定义3);
                Assert.AreEqual(data.SRDesc, "L62");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            SaleReturn v = new SaleReturn();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.SRID = "qH2ATmQ";
                v.CustomersID = AddCustomers();
                v.DepotsID = AddDepots();
                v.SRState = SCMSupplyChain.Model.SRState.未定义3;
                v.SRDesc = "jubk";
                context.Set<SaleReturn>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            SaleReturn v1 = new SaleReturn();
            SaleReturn v2 = new SaleReturn();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.SRID = "qH2ATmQ";
                v1.CustomersID = AddCustomers();
                v1.DepotsID = AddDepots();
                v1.SRState = SCMSupplyChain.Model.SRState.未定义3;
                v1.SRDesc = "jubk";
                v2.SRID = "2Fx2f";
                v2.CustomersID = v1.CustomersID; 
                v2.DepotsID = v1.DepotsID; 
                v2.SRState = SCMSupplyChain.Model.SRState.未定义3;
                v2.SRDesc = "L62";
                context.Set<SaleReturn>().Add(v1);
                context.Set<SaleReturn>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<SaleReturn>().Find(v1.ID);
                var data2 = context.Set<SaleReturn>().Find(v2.ID);
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

                v.CusName = "ZQ1ISmv";
                v.CusGrade = SCMSupplyChain.Model.CusGrade.VIP4;
                v.CusCompany = "TO97";
                v.CusMan = "cnf";
                v.CusTelephone = "w5gaw";
                v.CusDesc = "EYd";
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

                v.DepotName = "aNC3";
                v.DepotMan = "iofuDHj";
                v.DepotTelephone = "DdzgZv";
                v.DepotAddress = "XRriy";
                v.DepotDesc = "CHDD";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
