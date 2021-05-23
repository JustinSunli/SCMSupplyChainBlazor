using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.InboundData.StocksVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class StocksApiTest
    {
        private StocksController _controller;
        private string _seed;

        public StocksApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<StocksController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new StocksSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            StocksVM vm = _controller.Wtm.CreateVM<StocksVM>();
            Stocks v = new Stocks();
            
            v.StockID = "3wO";
            v.ProductLendID = AddProductLend();
            v.StockState = SCMSupplyChain.Model.StockState.未定义1;
            v.StockDesc = "xDxLcNW";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Stocks>().Find(v.ID);
                
                Assert.AreEqual(data.StockID, "3wO");
                Assert.AreEqual(data.StockState, SCMSupplyChain.Model.StockState.未定义1);
                Assert.AreEqual(data.StockDesc, "xDxLcNW");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Stocks v = new Stocks();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.StockID = "3wO";
                v.ProductLendID = AddProductLend();
                v.StockState = SCMSupplyChain.Model.StockState.未定义1;
                v.StockDesc = "xDxLcNW";
                context.Set<Stocks>().Add(v);
                context.SaveChanges();
            }

            StocksVM vm = _controller.Wtm.CreateVM<StocksVM>();
            var oldID = v.ID;
            v = new Stocks();
            v.ID = oldID;
       		
            v.StockID = "ky2CEt63";
            v.StockState = SCMSupplyChain.Model.StockState.未定义1;
            v.StockDesc = "ESn";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.StockID", "");
            vm.FC.Add("Entity.ProductLendID", "");
            vm.FC.Add("Entity.StockState", "");
            vm.FC.Add("Entity.StockDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Stocks>().Find(v.ID);
 				
                Assert.AreEqual(data.StockID, "ky2CEt63");
                Assert.AreEqual(data.StockState, SCMSupplyChain.Model.StockState.未定义1);
                Assert.AreEqual(data.StockDesc, "ESn");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Stocks v = new Stocks();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.StockID = "3wO";
                v.ProductLendID = AddProductLend();
                v.StockState = SCMSupplyChain.Model.StockState.未定义1;
                v.StockDesc = "xDxLcNW";
                context.Set<Stocks>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Stocks v1 = new Stocks();
            Stocks v2 = new Stocks();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.StockID = "3wO";
                v1.ProductLendID = AddProductLend();
                v1.StockState = SCMSupplyChain.Model.StockState.未定义1;
                v1.StockDesc = "xDxLcNW";
                v2.StockID = "ky2CEt63";
                v2.ProductLendID = v1.ProductLendID; 
                v2.StockState = SCMSupplyChain.Model.StockState.未定义1;
                v2.StockDesc = "ESn";
                context.Set<Stocks>().Add(v1);
                context.Set<Stocks>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Stocks>().Find(v1.ID);
                var data2 = context.Set<Stocks>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
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

                v.PPName = "2FJFfb";
                v.PPCompany = "4Cam6hU";
                v.PPMan = "feG";
                v.PPTel = "tSH4xzZZ";
                v.PPAddress = "hawr";
                v.PPFax = "6BKFih1Rs";
                v.Email = "0g5orPCJO";
                v.PPUrl = "kCp4Vi4h2";
                v.PPBank = "Rg6iZkJ1l";
                v.PPGoods = "ZlPitI";
                v.PPDesc = "rohFQ";
                context.Set<ProductLend>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
