using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.InboundData.StockInDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class StockInDepotApiTest
    {
        private StockInDepotController _controller;
        private string _seed;

        public StockInDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<StockInDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new StockInDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            StockInDepotVM vm = _controller.Wtm.CreateVM<StockInDepotVM>();
            StockInDepot v = new StockInDepot();
            
            v.SIDID = "tax";
            v.ProductLendID = AddProductLend();
            v.DepotsID = AddDepots();
            v.StocksID = AddStocks();
            v.SIDDeliver = "MDcpYxQ";
            v.SIDFreight = 15;
            v.SIDData = SCMSupplyChain.Model.SIDData.未定义1;
            v.SIDDesc = "SBi";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StockInDepot>().Find(v.ID);
                
                Assert.AreEqual(data.SIDID, "tax");
                Assert.AreEqual(data.SIDDeliver, "MDcpYxQ");
                Assert.AreEqual(data.SIDFreight, 15);
                Assert.AreEqual(data.SIDData, SCMSupplyChain.Model.SIDData.未定义1);
                Assert.AreEqual(data.SIDDesc, "SBi");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            StockInDepot v = new StockInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.SIDID = "tax";
                v.ProductLendID = AddProductLend();
                v.DepotsID = AddDepots();
                v.StocksID = AddStocks();
                v.SIDDeliver = "MDcpYxQ";
                v.SIDFreight = 15;
                v.SIDData = SCMSupplyChain.Model.SIDData.未定义1;
                v.SIDDesc = "SBi";
                context.Set<StockInDepot>().Add(v);
                context.SaveChanges();
            }

            StockInDepotVM vm = _controller.Wtm.CreateVM<StockInDepotVM>();
            var oldID = v.ID;
            v = new StockInDepot();
            v.ID = oldID;
       		
            v.SIDID = "mH1ZBXEQ";
            v.SIDDeliver = "FUqR1pOx";
            v.SIDFreight = 38;
            v.SIDData = SCMSupplyChain.Model.SIDData.未定义2;
            v.SIDDesc = "6uQm6FHC";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SIDID", "");
            vm.FC.Add("Entity.ProductLendID", "");
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.StocksID", "");
            vm.FC.Add("Entity.SIDDeliver", "");
            vm.FC.Add("Entity.SIDFreight", "");
            vm.FC.Add("Entity.SIDData", "");
            vm.FC.Add("Entity.SIDDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StockInDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.SIDID, "mH1ZBXEQ");
                Assert.AreEqual(data.SIDDeliver, "FUqR1pOx");
                Assert.AreEqual(data.SIDFreight, 38);
                Assert.AreEqual(data.SIDData, SCMSupplyChain.Model.SIDData.未定义2);
                Assert.AreEqual(data.SIDDesc, "6uQm6FHC");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            StockInDepot v = new StockInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.SIDID = "tax";
                v.ProductLendID = AddProductLend();
                v.DepotsID = AddDepots();
                v.StocksID = AddStocks();
                v.SIDDeliver = "MDcpYxQ";
                v.SIDFreight = 15;
                v.SIDData = SCMSupplyChain.Model.SIDData.未定义1;
                v.SIDDesc = "SBi";
                context.Set<StockInDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            StockInDepot v1 = new StockInDepot();
            StockInDepot v2 = new StockInDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.SIDID = "tax";
                v1.ProductLendID = AddProductLend();
                v1.DepotsID = AddDepots();
                v1.StocksID = AddStocks();
                v1.SIDDeliver = "MDcpYxQ";
                v1.SIDFreight = 15;
                v1.SIDData = SCMSupplyChain.Model.SIDData.未定义1;
                v1.SIDDesc = "SBi";
                v2.SIDID = "mH1ZBXEQ";
                v2.ProductLendID = v1.ProductLendID; 
                v2.DepotsID = v1.DepotsID; 
                v2.StocksID = v1.StocksID; 
                v2.SIDDeliver = "FUqR1pOx";
                v2.SIDFreight = 38;
                v2.SIDData = SCMSupplyChain.Model.SIDData.未定义2;
                v2.SIDDesc = "6uQm6FHC";
                context.Set<StockInDepot>().Add(v1);
                context.Set<StockInDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<StockInDepot>().Find(v1.ID);
                var data2 = context.Set<StockInDepot>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddProductLend()
        {
            ProductLend v = new ProductLend();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.PPName = "XeyRpyJ";
                v.PPCompany = "NagQSeGX7";
                v.PPMan = "42dA";
                v.PPTel = "tCNP";
                v.PPAddress = "HhRt";
                v.PPFax = "m4T7j";
                v.Email = "dTntSyfqx";
                v.PPUrl = "cQJoJtNzP";
                v.PPBank = "juM";
                v.PPGoods = "EwJqfYu";
                v.PPDesc = "WT8c";
                context.Set<ProductLend>().Add(v);
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

                v.DepotName = "CkzB";
                v.DepotMan = "umY";
                v.DepotTelephone = "zEUgS";
                v.DepotAddress = "CN4OW0n";
                v.DepotDesc = "aDMMkGiXn";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddStocks()
        {
            Stocks v = new Stocks();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.StockID = "RRmG2rXs";
                v.ProductLendID = AddProductLend();
                v.StockState = SCMSupplyChain.Model.StockState.未定义3;
                v.StockDesc = "nUU";
                context.Set<Stocks>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
