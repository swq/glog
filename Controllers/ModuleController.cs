using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data.Entity;
namespace gLog_FrontEnd.Controllers
{
    public class ModuleController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();
        //
        // GET: /Module/
        [AdminLayout]
        public ActionResult Index() 
        {
            return View();
        }

        //获取数据
        public JsonResult Get_Parent_Module(int limit, int offset, string departmentname, string statu)
        {
            var Module = db.T_Auth_Module.AsNoTracking().Where(s => s.IsDeleted == false && s.ParentId == null)
                .Select(s =>new { s.Id, s.Name, s.Code, s.Icon, s.OrderSort, s.Enabled, s.LinkUrl, s.IsMenu, s.ParentId, s.Action, s.Controller})
                .OrderBy(s => s.OrderSort)
                .Skip(offset)
                .Take(limit)
                .ToList();
            var total = Module.Count;
            //var rows = Module.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = Module }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Child_Module(int strParentID)
        {
            var Module = db.T_Auth_Module.AsNoTracking().Where(s => s.IsDeleted == false && s.ParentId == strParentID)
                .Select(s => new { s.Id, s.Name, s.Code, s.Icon, s.OrderSort, s.Enabled, s.LinkUrl, s.IsMenu, s.ParentId, s.Action, s.Controller, ParentName = s.T_Auth_Module2.Name })
                .OrderBy(s => s.OrderSort)
                .ToList();
            var total = Module.Count;
            return Json(new { total = total, rows = Module }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Modules()
        {
            var Modules = db.T_Auth_Module.AsNoTracking().Where(s => s.IsDeleted == false).Select(s =>
                new { s.Id, s.Name}).ToList();

            return Json(new { Msg = "成功", data = Modules }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEdit(string data)
        {
            var Userinfo = Session["User"] as T_Auth_User;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Module = js.Deserialize<T_Auth_Module>(data);
            if (Module.Id == -1)
            {
                Module.IsDeleted = false;
                Module.ModifyId = Userinfo.Id;
                Module.ModifyBy = Userinfo.LoginName;
                Module.ModifyTime = DateTime.Now;
                db.T_Auth_Module.Add(Module);
            }
            else
            {
                Module.ModifyId = Userinfo.Id;
                Module.ModifyBy = Userinfo.LoginName;
                Module.ModifyTime = DateTime.Now;
                DbEntityEntry<T_Auth_Module> dbEntry = db.Entry<T_Auth_Module>(Module);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.Name).IsModified = true;
                dbEntry.Property(s => s.Code).IsModified = true;
                dbEntry.Property(s => s.Icon).IsModified = true;
                dbEntry.Property(s => s.OrderSort).IsModified = true;
                dbEntry.Property(s => s.Controller).IsModified = true;
                dbEntry.Property(s => s.Action).IsModified = true;
                dbEntry.Property(s => s.IsMenu).IsModified = true;
                dbEntry.Property(s => s.Enabled).IsModified = true;
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }

        //提交删除
        [HttpPost]
        public JsonResult Del(string data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Module = js.Deserialize<T_Auth_Module>(data);
            Module.IsDeleted = true;
            db.Entry(Module).State = EntityState.Unchanged;
            db.Entry(Module).Property(s => s.IsDeleted).IsModified = true;

            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Roles(int ModuleId)
        {
            var Roles = db.T_Auth_Permission.AsNoTracking().Where(s => s.IsDeleted == false)
                .Select(s =>
                new { s.Id, 
                      s.Name, 
                      IsChecked = s.T_Auth_ModulePermission.AsQueryable().Where(s1 => s1.ModuleId == ModuleId && s1.IsDeleted == false).Select(s1 => s1.ModuleId).FirstOrDefault() 
                }) .ToList();

            //外链接方式
            //var query = (from Perm in db.T_Auth_Permission
            //             join M_Perm in db.T_Auth_ModulePermission
            //                on Perm.Id equals M_Perm.PermissionId
            //                into temps
            //             from temp in temps.DefaultIfEmpty()
            //             select new
            //             {
            //                 Perm.Id,
            //                 Perm.Name,
            //                 temp.ModuleId
            //             });

            return Json(new { Msg = "成功", data = Roles }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Sub_ModulePermission(string data, int ModuleId)
        {
            var Userinfo = Session["User"] as T_Auth_User;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var L_Id = js.Deserialize<List<int>>(data);

            var oldDataList = db.T_Auth_ModulePermission.Where(t => t.ModuleId == ModuleId && t.IsDeleted == false).Select(t => t.PermissionId).ToList();
            var newDataList = js.Deserialize<List<int>>(data);
            var intersectIds = oldDataList.Intersect(newDataList).ToList(); // Same Ids
            var updateIds = oldDataList.Except(intersectIds).ToList(); // Remove Ids
            var addIds = newDataList.Except(oldDataList).ToList(); // Add Ids
            //逻辑删除
            foreach (var removeId in updateIds)
            {
                var updateEntity = db.T_Auth_ModulePermission.AsNoTracking().FirstOrDefault(t => t.ModuleId == ModuleId && t.PermissionId == removeId && t.IsDeleted == false);
                if (updateEntity != null)
                {
                    updateEntity.IsDeleted = true;
                    db.Entry(updateEntity).State = EntityState.Unchanged;
                    db.Entry(updateEntity).Property(s => s.IsDeleted).IsModified = true;
                }
            }
            //插入 & 更新
            foreach (var addId in addIds)
            {
                var updateEntity = db.T_Auth_ModulePermission.AsNoTracking().FirstOrDefault(t => t.ModuleId == ModuleId && t.PermissionId == addId && t.IsDeleted == true);
                if (updateEntity != null)
                {
                    updateEntity.IsDeleted = false;
                    updateEntity.ModifyId = Userinfo.Id;
                    updateEntity.ModifyBy = Userinfo.LoginName;
                    db.Entry(updateEntity).State = EntityState.Unchanged;
                    db.Entry(updateEntity).Property(s => s.IsDeleted).IsModified = true;
                    db.Entry(updateEntity).Property(s => s.ModifyId).IsModified = true;
                    db.Entry(updateEntity).Property(s => s.ModifyBy).IsModified = true;
                }
                else
                {
                    var addEntity = new T_Auth_ModulePermission {
                        ModuleId = ModuleId,
                        PermissionId = addId ,
                        CreateTime =DateTime.Now,
                        ModifyId = Userinfo.Id,
                        ModifyBy = Userinfo.LoginName,
                        IsDeleted =false};
                    db.T_Auth_ModulePermission.Add(addEntity);
                }
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { Msg = status }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_Modules_tree(int RoleId)
        {
            var Modules = db.T_Auth_Module.AsNoTracking().Where(s => s.IsDeleted == false).Select(s =>
                new { id = s.Id, pId = s.ParentId, name = s.Name}); //checked:true
            var right = db.T_Auth_RoleModulePermission.Where(s => s.RoleId == RoleId && s.IsDeleted == false)
                        .Select(s => new { s.ModuleId }).Distinct();
            var datas = (from L in Modules
                         join R in right on L.id equals R.ModuleId into temps
                         from temp in temps.DefaultIfEmpty()
                         select new
                         {
                             id = L.id,
                             pId = L.pId,
                             name = L.name,
                             @checked = temp.ModuleId != null ? true : false
                         }).ToList();
            return Json(new { Msg = "成功", data = datas }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Roles_tree(int ModuleId,int RoleId)
        {
            var Left_Roles = db.T_Auth_ModulePermission.AsNoTracking()
                .Where(s => s.IsDeleted == false && s.ModuleId == ModuleId)
                .Select(s => new { s.Id,s.PermissionId, s.T_Auth_Permission.Name });

            var right_Roles = db.T_Auth_RoleModulePermission.AsNoTracking()
                .Where(s => s.IsDeleted == false && s.ModuleId == ModuleId && s.RoleId == RoleId)
                .Select(s => new { s.ModuleId, s.PermissionId});
            checked
            {

            }
            //外链接方式
            var Roles = (from Perm in Left_Roles
                          join M_Perm in right_Roles
                            on Perm.PermissionId equals M_Perm.PermissionId
                            into temps
                         from temp in temps.DefaultIfEmpty()
                          select new {
                             Perm.PermissionId,
                             Perm.Name,
                             IsChecked = temp.PermissionId == null ? 0 : temp.PermissionId
                          }).ToList();
            
            return Json(new { Msg = "成功", data = Roles }, JsonRequestBehavior.AllowGet);
        }
    }
}
