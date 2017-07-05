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
    public class PermissionController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();
        //
        // GET: /Permission/
        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }

        //获取用户数据
        public JsonResult GetPermission(int limit, int offset, string departmentname, string statu)
        {
            var Permission = db.T_Auth_Permission.Where(s => s.IsDeleted == false).Select(s =>
                new { s.Id, s.Name, s.Code, s.Icon, s.SortOrder, s.Enabled }).ToList();
            var total = Permission.Count;
            var rows = Permission.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }

        //提交删除
        [HttpPost]
        public JsonResult Del(string data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Permissions = js.Deserialize<List<T_Auth_Permission>>(data);
            foreach (var temp in Permissions)
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

        //提交创建和修改
        [HttpPost]
        public JsonResult GetEdit(string data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Permission = js.Deserialize<T_Auth_Permission>(data);
            if (Permission.Id == -1)
            {
                Permission.IsDeleted = false;
                db.T_Auth_Permission.Add(Permission);
            }
            else
            {
                DbEntityEntry<T_Auth_Permission> dbEntry = db.Entry<T_Auth_Permission>(Permission);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.Name).IsModified = true;
                dbEntry.Property(s => s.Code).IsModified = true;
                dbEntry.Property(s => s.Icon).IsModified = true;
                dbEntry.Property(s => s.SortOrder).IsModified = true;
                dbEntry.Property(s => s.Enabled).IsModified = true;
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }
    }
}
