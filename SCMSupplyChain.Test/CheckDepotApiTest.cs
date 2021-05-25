using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using SCMSupplyChain.Controllers;
using SCMSupplyChain.ViewModel.Inventory.CheckDepotVMs;
using SCMSupplyChain.Model;
using SCMSupplyChain.DataAccess;


namespace SCMSupplyChain.Test
{
    [TestClass]
    public class CheckDepotApiTest
    {
        private CheckDepotController _controller;
        private string _seed;

        public CheckDepotApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<CheckDepotController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new CheckDepotSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            CheckDepotVM vm = _controller.Wtm.CreateVM<CheckDepotVM>();
            CheckDepot v = new CheckDepot();
            
            v.DepotsID = AddDepots();
            v.FrameworkUserID = AddFrameworkUser();
            v.CDState = SCMSupplyChain.Model.CDState.盘点中;
            v.CDDesc = "f8r";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<CheckDepot>().Find(v.ID);
                
                Assert.AreEqual(data.CDState, SCMSupplyChain.Model.CDState.盘点中);
                Assert.AreEqual(data.CDDesc, "f8r");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            CheckDepot v = new CheckDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DepotsID = AddDepots();
                v.FrameworkUserID = AddFrameworkUser();
                v.CDState = SCMSupplyChain.Model.CDState.盘点中;
                v.CDDesc = "f8r";
                context.Set<CheckDepot>().Add(v);
                context.SaveChanges();
            }

            CheckDepotVM vm = _controller.Wtm.CreateVM<CheckDepotVM>();
            var oldID = v.ID;
            v = new CheckDepot();
            v.ID = oldID;
       		
            v.CDState = SCMSupplyChain.Model.CDState.盘点核算;
            v.CDDesc = "Z1chJ";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DepotsID", "");
            vm.FC.Add("Entity.FrameworkUserID", "");
            vm.FC.Add("Entity.CDState", "");
            vm.FC.Add("Entity.CDDesc", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<CheckDepot>().Find(v.ID);
 				
                Assert.AreEqual(data.CDState, SCMSupplyChain.Model.CDState.盘点核算);
                Assert.AreEqual(data.CDDesc, "Z1chJ");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            CheckDepot v = new CheckDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DepotsID = AddDepots();
                v.FrameworkUserID = AddFrameworkUser();
                v.CDState = SCMSupplyChain.Model.CDState.盘点中;
                v.CDDesc = "f8r";
                context.Set<CheckDepot>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            CheckDepot v1 = new CheckDepot();
            CheckDepot v2 = new CheckDepot();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DepotsID = AddDepots();
                v1.FrameworkUserID = AddFrameworkUser();
                v1.CDState = SCMSupplyChain.Model.CDState.盘点中;
                v1.CDDesc = "f8r";
                v2.DepotsID = v1.DepotsID; 
                v2.FrameworkUserID = v1.FrameworkUserID; 
                v2.CDState = SCMSupplyChain.Model.CDState.盘点核算;
                v2.CDDesc = "Z1chJ";
                context.Set<CheckDepot>().Add(v1);
                context.Set<CheckDepot>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<CheckDepot>().Find(v1.ID);
                var data2 = context.Set<CheckDepot>().Find(v2.ID);
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

                v.DepotName = "yYVzxEE";
                v.DepotMan = "dh0yM";
                v.DepotTelephone = "DqBn1";
                v.DepotAddress = "fRbli9ByY";
                v.DepotDesc = "FWDQKXsj7";
                context.Set<Depots>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "JftDUtPtz";
                v.FileExt = "QXBBf8FD";
                v.Path = "Wkn";
                v.Length = 80;
                v.SaveMode = "pPHfRJ";
                v.ExtraInfo = "7a6ky";
                v.HandlerInfo = "dT5K";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFrameworkUser()
        {
            FrameworkUser v = new FrameworkUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Email = "fyx8AL";
                v.Gender = WalkingTec.Mvvm.Core.GenderEnum.Male;
                v.CellPhone = "VhVHbt";
                v.HomePhone = "SIq";
                v.Address = "uNGP";
                v.ZipCode = "cvNOi7y";
                v.ITCode = "Rn420zOaz";
                v.Password = "X8t";
                v.Name = "7eaVN";
                v.IsValid = false;
                v.PhotoId = AddFileAttachment();
                v.TenantCode = "SzX1MPQ";
                context.Set<FrameworkUser>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
