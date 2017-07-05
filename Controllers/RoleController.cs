using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Data;
using System.Data.Entity.Infrastructure;
using gLog_FrontEnd.DTO;
using System.Data.Entity;
namespace gLog_FrontEnd.Controllers
{
    public class RoleController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();

        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRole(int limit, int offset, string departmentname, string statu)
        {

            var Roles = db.T_Auth_Role.AsNoTracking().Where(s => s.IsDeleted == false)
                .Select(s => new { s.Id, s.Name, s.Description, s.OrderSort, s.Enabled })
                .OrderBy(s => s.OrderSort)
                .Skip(offset)
                .Take(limit)
                .ToList();
            var total = Roles.Count;

            return Json(new { total = total, rows = Roles }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEdit(string data)
        {
            var User = Session["User"] as T_Auth_User;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Role = js.Deserialize<T_Auth_Role>(data);
            if (Role.Id == -1)
            {
                Role.CreateId = User.Id;
                Role.CreateBy = User.LoginName;
                Role.CreateTime = DateTime.Now;
                Role.IsDeleted = false;
                db.T_Auth_Role.Add(Role);
            }
            else
            {
                Role.ModifyId = User.Id;
                Role.ModifyBy = User.LoginName;
                Role.ModifyTime = DateTime.Now;
                db.Entry(Role).State = EntityState.Unchanged;
                db.Entry(Role).Property(s => s.Name).IsModified = true;
                db.Entry(Role).Property(s => s.Description).IsModified = true;
                db.Entry(Role).Property(s => s.ModifyId).IsModified = true;
                db.Entry(Role).Property(s => s.ModifyBy).IsModified = true;
                db.Entry(Role).Property(s => s.ModifyTime).IsModified = true;
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
            var Roles = js.Deserialize<List<T_Auth_Role>>(data);
            foreach (var temp in Roles)
            {
                temp.IsDeleted = true;
                db.Entry(temp).State = EntityState.Unchanged;
                db.Entry(temp).Property(s => s.IsDeleted).IsModified = true;
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save_RoleModlePermission(string data, int RoleId,int ModuleId)
        {
            var Userinfo = Session["User"] as T_Auth_User;
            JavaScriptSerializer js = new JavaScriptSerializer();
            //var Roles = js.Deserialize<List<int>>(data);
            var oldDataList = db.T_Auth_RoleModulePermission
                .Where(t => t.ModuleId == ModuleId && t.RoleId == RoleId && t.IsDeleted == false)
                .Select(t => t.PermissionId == null ? 0: (int)t.PermissionId).ToList();

            var newDataList = js.Deserialize<List<int>>(data);
            var intersectIds = oldDataList.Intersect(newDataList).ToList(); // Same Ids
            var updateIds = oldDataList.Except(intersectIds).ToList(); // Remove Ids
            var addIds = newDataList.Except(oldDataList).ToList(); // Add Ids
            //逻辑删除
            foreach (var removeId in updateIds)
            {
                var updateEntity = db.T_Auth_RoleModulePermission.AsNoTracking()
                    .FirstOrDefault(
                    t => t.RoleId == RoleId 
                    && t.ModuleId == ModuleId 
                    && t.PermissionId == removeId 
                    && t.IsDeleted == false);

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
                var updateEntity = db.T_Auth_RoleModulePermission.AsNoTracking()
                    .FirstOrDefault(
                    t => t.RoleId == RoleId 
                    && t.ModuleId == ModuleId 
                    && t.PermissionId == addId
                    && t.IsDeleted == true);

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
                    var addEntity = new T_Auth_RoleModulePermission
                    {
                        RoleId = RoleId,
                        ModuleId = ModuleId,
                        PermissionId = addId,
                        CreateTime = DateTime.Now,
                        ModifyId = Userinfo.Id,
                        ModifyBy = Userinfo.LoginName,
                        IsDeleted = false
                    };
                    db.T_Auth_RoleModulePermission.Add(addEntity);
                }
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { Msg = status }, JsonRequestBehavior.AllowGet);
        }
    }
}