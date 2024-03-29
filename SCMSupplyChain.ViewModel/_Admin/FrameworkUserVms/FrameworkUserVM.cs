// WTM默认页面 Wtm buidin page
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkUserVms
{
    public class FrameworkUserVM : BaseCRUDVM<FrameworkUser>
    {
        [Display(Name = "_Admin.Role")]
        public List<string> SelectedRolesCodes { get; set; }
        [Display(Name = "_Admin.Group")]
        public List<string> SelectedGroupCodes { get; set; }


        public FrameworkUserVM()
        {
        }

        /// <summary>
        /// 验证重复字段
        /// </summary>
        /// <returns></returns>
        public override DuplicatedInfo<FrameworkUser> SetDuplicatedCheck()
        {
            var rv = CreateFieldsInfo(SimpleField(x => x.ITCode));
            return rv;
        }

        protected override void InitVM()
        {
            SelectedRolesCodes = DC.Set<FrameworkUserRole>().Where(x=>x.UserCode == Entity.ITCode).Select(x=>x.RoleCode).ToList();
            SelectedGroupCodes = DC.Set<FrameworkUserGroup>().Where(x => x.UserCode == Entity.ITCode).Select(x => x.GroupCode).ToList();
        }

        public override async Task DoAddAsync()
        {
            using (var trans = DC.BeginTransaction())
            {
                if (SelectedRolesCodes != null)
                {
                    foreach (var rolecode in SelectedRolesCodes)
                    {
                        FrameworkUserRole r = new FrameworkUserRole
                        {
                            RoleCode = rolecode,
                            UserCode = Entity.ITCode
                        };
                        DC.AddEntity(r);
                    }
                }
                if (SelectedGroupCodes != null)
                {
                    foreach (var groupcode in SelectedGroupCodes)
                    {
                        FrameworkUserGroup g = new FrameworkUserGroup
                        {
                            GroupCode = groupcode,
                            UserCode = Entity.ITCode
                        };
                        DC.AddEntity(g);
                    }
                }
                Entity.IsValid = true;
                Entity.Password = Utils.GetMD5String(Entity.Password);
                await base.DoAddAsync();
                if (MSD.IsValid)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
        }

        public override async Task DoEditAsync(bool updateAllFields = false)
        {
            if (FC.ContainsKey("Entity.ITCode"))
            {
                FC.Remove("Entity.ITCode");
            }
            using (var trans = DC.BeginTransaction())
            {
                if(SelectedRolesCodes != null)
                {
                    List<Guid> todelete = new List<Guid>();
                    todelete.AddRange( DC.Set<FrameworkUserRole>().AsNoTracking().Where(x=> x.UserCode == Entity.ITCode).Select(x=>x.ID));
                    foreach (var item in todelete)
                    {
                        DC.DeleteEntity(new FrameworkUserRole { ID = item });
                    }
                }
                if (SelectedGroupCodes != null)
                {
                    List<Guid> todelete = new List<Guid>();
                    todelete.AddRange(DC.Set<FrameworkUserGroup>().AsNoTracking().Where(x => x.UserCode == Entity.ITCode).Select(x => x.ID));
                    foreach (var item in todelete)
                    {
                        DC.DeleteEntity(new FrameworkUserGroup { ID = item });
                    }
                }
                if (SelectedRolesCodes != null)
                {
                    foreach (var rolecode in SelectedRolesCodes)
                    {
                        FrameworkUserRole r = new FrameworkUserRole
                        {
                            RoleCode = rolecode,
                            UserCode = Entity.ITCode
                        };
                        DC.AddEntity(r);
                    }
                }
                if (SelectedGroupCodes != null)
                {
                    foreach (var groupcode in SelectedGroupCodes)
                    {
                        FrameworkUserGroup g = new FrameworkUserGroup
                        {
                            GroupCode = groupcode,
                            UserCode = Entity.ITCode
                        };
                        DC.AddEntity(g);
                    }
                }
                await base.DoEditAsync(updateAllFields);
                if (MSD.IsValid)
                {
                    trans.Commit();
                    await Wtm.RemoveUserCache(Entity.ITCode.ToString());
                }
                else
                {
                    trans.Rollback();
                }
            }
        }

        public override async Task DoDeleteAsync()
        {
            await base.DoDeleteAsync();
            await Wtm.RemoveUserCache(Entity.ITCode.ToString());
        }

        public void ChangePassword()
        {
            Entity.Password = Utils.GetMD5String(Entity.Password);
            DC.UpdateProperty(Entity, x => x.Password);
            DC.SaveChanges();
        }
    }
}
