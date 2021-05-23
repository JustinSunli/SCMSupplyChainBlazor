using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.BasicData.ProductLendVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class ProductLendApiTest
    {
        private ProductLendController _controller;
        private string _seed;

        public ProductLendApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ProductLendController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ProductLendSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ProductLendVM vm = _controller.Wtm.CreateVM<ProductLendVM>();
            ProductLend v = new ProductLend();
            
            v.PPName = "v2oN";
            v.PPCompany = "Sza6IW";
            v.PPMan = "IJ5X";
            v.PPTel = "kpXu4";
            v.PPAddress = "nJ4OQ4";
            v.PPFax = "m42oqLkCB";
            v.Email = "6ajhl";
            v.PPUrl = "yrt2p";
            v.PPBank = "POf9cnR";
            v.PPGoods = "VzWw6F";
            v.PPDesc = "brh6";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductLend>().Find(v.ID);
                
                Assert.AreEqual(data.PPName, "v2oN");
                Assert.AreEqual(data.PPCompany, "Sza6IW");
                Assert.AreEqual(data.PPMan, "IJ5X");
                Assert.AreEqual(data.PPTel, "kpXu4");
                Assert.AreEqual(data.PPAddress, "nJ4OQ4");
                Assert.AreEqual(data.PPFax, "m42oqLkCB");
                Assert.AreEqual(data.Email, "6ajhl");
                Assert.AreEqual(data.PPUrl, "yrt2p");
                Assert.AreEqual(data.PPBank, "POf9cnR");
                Assert.AreEqual(data.PPGoods, "VzWw6F");
                Assert.AreEqual(data.PPDesc, "brh6");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ProductLend v = new ProductLend();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.PPName = "v2oN";
                v.PPCompany = "Sza6IW";
                v.PPMan = "IJ5X";
                v.PPTel = "kpXu4";
                v.PPAddress = "nJ4OQ4";
                v.PPFax = "m42oqLkCB";
                v.Email = "6ajhl";
                v.PPUrl = "yrt2p";
                v.PPBank = "POf9cnR";
                v.PPGoods = "VzWw6F";
                v.PPDesc = "brh6";
                context.Set<ProductLend>().Add(v);
                context.SaveChanges();
            }

            ProductLendVM vm = _controller.Wtm.CreateVM<ProductLendVM>();
            var oldID = v.ID;
            v = new ProductLend();
            v.ID = oldID;
       		
            v.PPName = "IUBI5yl";
            v.PPCompany = "wAt";
            v.PPMan = "ws9LAcKGM";
            v.PPTel = "hAi8";
            v.PPAddress = "HElI1hP";
            v.PPFax = "uzO";
            v.Email = "I1kyoqEnL";
            v.PPUrl = "OvZWiPl";
            v.PPBank = "xdTSPahAz";
            v.PPGoods = "dCaFM";
            v.PPDesc = "Ec5RFf";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.PPName", "");
            vm.FC.Add("Entity.PPCompany", "");
            vm.FC.Add("Entity.PPMan", "");
            vm.FC.Add("Entity.PPTel", "");
            vm.FC.Add("Entity.PPAddress", "");
            vm.FC.Add("Entity.PPFax", "");
            vm.FC.Add("Entity.Email", "");
            vm.FC.Add("Entity.PPUrl", "");
            vm.FC.Add("Entity.PPBank", "");
            vm.FC.Add("Entity.PPGoods", "");
            vm.FC.Add("Entity.PPDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProductLend>().Find(v.ID);
 				
                Assert.AreEqual(data.PPName, "IUBI5yl");
                Assert.AreEqual(data.PPCompany, "wAt");
                Assert.AreEqual(data.PPMan, "ws9LAcKGM");
                Assert.AreEqual(data.PPTel, "hAi8");
                Assert.AreEqual(data.PPAddress, "HElI1hP");
                Assert.AreEqual(data.PPFax, "uzO");
                Assert.AreEqual(data.Email, "I1kyoqEnL");
                Assert.AreEqual(data.PPUrl, "OvZWiPl");
                Assert.AreEqual(data.PPBank, "xdTSPahAz");
                Assert.AreEqual(data.PPGoods, "dCaFM");
                Assert.AreEqual(data.PPDesc, "Ec5RFf");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ProductLend v = new ProductLend();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.PPName = "v2oN";
                v.PPCompany = "Sza6IW";
                v.PPMan = "IJ5X";
                v.PPTel = "kpXu4";
                v.PPAddress = "nJ4OQ4";
                v.PPFax = "m42oqLkCB";
                v.Email = "6ajhl";
                v.PPUrl = "yrt2p";
                v.PPBank = "POf9cnR";
                v.PPGoods = "VzWw6F";
                v.PPDesc = "brh6";
                context.Set<ProductLend>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProductLend v1 = new ProductLend();
            ProductLend v2 = new ProductLend();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.PPName = "v2oN";
                v1.PPCompany = "Sza6IW";
                v1.PPMan = "IJ5X";
                v1.PPTel = "kpXu4";
                v1.PPAddress = "nJ4OQ4";
                v1.PPFax = "m42oqLkCB";
                v1.Email = "6ajhl";
                v1.PPUrl = "yrt2p";
                v1.PPBank = "POf9cnR";
                v1.PPGoods = "VzWw6F";
                v1.PPDesc = "brh6";
                v2.PPName = "IUBI5yl";
                v2.PPCompany = "wAt";
                v2.PPMan = "ws9LAcKGM";
                v2.PPTel = "hAi8";
                v2.PPAddress = "HElI1hP";
                v2.PPFax = "uzO";
                v2.Email = "I1kyoqEnL";
                v2.PPUrl = "OvZWiPl";
                v2.PPBank = "xdTSPahAz";
                v2.PPGoods = "dCaFM";
                v2.PPDesc = "Ec5RFf";
                context.Set<ProductLend>().Add(v1);
                context.Set<ProductLend>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ProductLend>().Find(v1.ID);
                var data2 = context.Set<ProductLend>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
