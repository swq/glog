using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class DataDictionaryController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();
        // GET: DataDictionary

        #region ProState-工程状态
        [AdminLayout]
        public ActionResult ProStateIndex()
        {
            return View();
        }
        //获取用户数据
        public JsonResult GetProState(int limit, int offset, string departmentname, string statu)
        {
            var ProState = db.TC_ProjectState.Where(s => s.IsDeleted == false).Select(s =>
                new { s.ID, s.PJ_State,s.PJ_State_EN, s.Note, s.SortOrder, s.Enable}).ToList();
            var total = ProState.Count;
            var rows = ProState.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }
        //提交创建和修改
        [HttpPost]
        public JsonResult ProStateGetEdit(string data)
        {
            var User = Session["User"] as T_Auth_User;
            var ProjectState = JsonConvert.DeserializeObject<TC_ProjectState>(data);
            if (ProjectState.ID == -1)
            {
                ProjectState.IsDeleted = false;
                ProjectState.CreateDate = DateTime.Now;
                ProjectState.CreateUserCode = User.LoginName;
                ProjectState.CreateUserID = User.Id;
                db.TC_ProjectState.Add(ProjectState);
            }
            else
            {
                ProjectState.ModifiedDate = DateTime.Now;
                ProjectState.ModifiedUserCode = User.LoginName;
                ProjectState.ModifiedUserID = User.Id;
                DbEntityEntry<TC_ProjectState> dbEntry = db.Entry<TC_ProjectState>(ProjectState);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.Enable).IsModified = true;
                dbEntry.Property(s => s.PJ_State).IsModified = true;
                dbEntry.Property(s => s.PJ_State_EN).IsModified = true;
                dbEntry.Property(s => s.Note).IsModified = true;
                dbEntry.Property(s => s.SortOrder).IsModified = true;
                dbEntry.Property(s => s.ModifiedDate).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserCode).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserID).IsModified = true;
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
        public JsonResult ProStateDel(string data)
        {

            var ProjectState = JsonConvert.DeserializeObject<List<TC_ProjectState>>(data);
            foreach (var temp in ProjectState)
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
        #endregion


        #region ProType-工程类型
        [AdminLayout]
        public ActionResult ProTypeIndex()
        {
            return View();
        }
        //获取用户数据
        public JsonResult GetProType(int limit, int offset, string departmentname, string statu)
        {
            var ProState = db.TC_ProjectType.Where(s => s.IsDeleted == false).Select(s =>
                new { s.ID, s.PJ_Type,s.PJ_Type_EN, s.Note, s.SortOrder, s.Enable }).ToList();
            var total = ProState.Count;
            var rows = ProState.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }
        //提交创建和修改
        [HttpPost]
        public JsonResult ProTypeGetEdit(string data)
        {
            //1.
            //var anonymous = new { a = 0, b = String.Empty, e = new DateTime(), c = new int[0], d = new Dictionary<string, int>() };
            //var o2 = JsonConvert.DeserializeAnonymousType(data, anonymous);
            //2.
            //var o3 = JsonConvert.DeserializeAnonymousType(data, new { c = new int[0], d = new Dictionary<string, int>() });
            //Console.WriteLine(o3.d["y"]);
            //3.
            //var o2 = JsonConvert.DeserializeObject(data) as JObject;
            //Console.WriteLine((int)o2["a"]);
            //Console.WriteLine((string)o2["b"]);
            //Console.WriteLine(o2["c"].Values().Count());
            //Console.WriteLine((int)o2["d"]["y"]);

            var User = Session["User"] as T_Auth_User;
            var ProjectType = JsonConvert.DeserializeObject<TC_ProjectType>(data);
            if (ProjectType.ID == -1)
            {
                ProjectType.IsDeleted = false;
                ProjectType.CreateDate = DateTime.Now;
                ProjectType.CreateUserCode = User.LoginName;
                ProjectType.CreateUserID = User.Id;
                db.TC_ProjectType.Add(ProjectType);
            }
            else
            {
                ProjectType.ModifiedDate = DateTime.Now;
                ProjectType.ModifiedUserCode = User.LoginName;
                ProjectType.ModifiedUserID = User.Id;
                DbEntityEntry<TC_ProjectType> dbEntry = db.Entry<TC_ProjectType>(ProjectType);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.Enable).IsModified = true;
                dbEntry.Property(s => s.PJ_Type).IsModified = true;
                dbEntry.Property(s => s.PJ_Type_EN).IsModified = true;
                dbEntry.Property(s => s.Note).IsModified = true;
                dbEntry.Property(s => s.SortOrder).IsModified = true;
                dbEntry.Property(s => s.ModifiedDate).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserCode).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserID).IsModified = true;
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
        public JsonResult ProTypeDel(string data)
        {

            var ProjectType = JsonConvert.DeserializeObject<List<TC_ProjectType>>(data);
            foreach (var temp in ProjectType)
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
        #endregion


        #region TC_GeographyArea-地理区域(欧洲，亚洲...)
        [AdminLayout]
        public ActionResult GeoAreaIndex()
        {
            return View();
        }
        //获取用户数据
        public JsonResult GetGeoArea(int limit, int offset, string departmentname, string statu)
        {
            var ProState = db.TC_GeographyArea.Where(s => s.IsDeleted == false).Select(s =>
                new { s.ID, s.Area, s.Area_EN, s.Note, s.SortOrder, s.Enable }).ToList();
            var total = ProState.Count;
            var rows = ProState.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }
        //提交创建和修改
        [HttpPost]
        public JsonResult GeoAreaGetEdit(string data)
        {
            var User = Session["User"] as T_Auth_User;
            var Area = JsonConvert.DeserializeObject<TC_GeographyArea>(data);
            if (Area.ID == -1)
            {
                Area.IsDeleted = false;
                Area.CreateDate = DateTime.Now;
                Area.CreateUserCode = User.LoginName;
                Area.CreateUserID = User.Id;
                db.TC_GeographyArea.Add(Area);
            }
            else
            {
                Area.ModifiedDate = DateTime.Now;
                Area.ModifiedUserCode = User.LoginName;
                Area.ModifiedUserID = User.Id;
                DbEntityEntry<TC_GeographyArea> dbEntry = db.Entry<TC_GeographyArea>(Area);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.Enable).IsModified = true;
                dbEntry.Property(s => s.Area).IsModified = true;
                dbEntry.Property(s => s.Area_EN).IsModified = true;
                dbEntry.Property(s => s.Note).IsModified = true;
                dbEntry.Property(s => s.SortOrder).IsModified = true;
                dbEntry.Property(s => s.ModifiedDate).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserCode).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserID).IsModified = true;
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
        public JsonResult GeoAreaDel(string data)
        {

            var ProjectType = JsonConvert.DeserializeObject<List<TC_GeographyArea>>(data);
            foreach (var temp in ProjectType)
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
        #endregion

        #region TC_Company-公司字典表
        [AdminLayout]
        public ActionResult CompanyIndex()
        {
            return View();
        }

        public JsonResult GetCompany(int limit, int offset, string departmentname, string statu)
        {
            var Companies = db.Set<TC_Company>().Where(s => s.IsDelete == false).Select(s =>
                new { s.ID,s.Company_Code, s.Company, s.Company_EN,s.Enable,s.SortOrder,s.Note }).ToList();
            var total = Companies.Count;
            var rows = Companies.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }
        //提交创建和修改
        [HttpPost]
        public JsonResult CompanyGetEdit(string data)
        {
            var User = Session["User"] as T_Auth_User;
            var Company = JsonConvert.DeserializeObject<TC_Company>(data);
            if (Company.ID == -1)
            {
                Company.IsDelete = false;
                Company.CreateDate = DateTime.Now;
                Company.CreateUserCode = User.LoginName;
                Company.CreateUserID = User.Id;
                db.Set<TC_Company>().Add(Company);
            }
            else
            {
                Company.ModifiedDate = DateTime.Now;
                Company.ModifiedUserCode = User.LoginName;
                Company.ModifiedUserID = User.Id;
                DbEntityEntry<TC_Company> dbEntry = db.Entry<TC_Company>(Company);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.Enable).IsModified = true;
                dbEntry.Property(s => s.Company).IsModified = true;
                dbEntry.Property(s => s.Company_EN).IsModified = true;
                dbEntry.Property(s => s.Company_Code).IsModified = true;
                dbEntry.Property(s => s.Note).IsModified = true;
                dbEntry.Property(s => s.SortOrder).IsModified = true;
                dbEntry.Property(s => s.ModifiedDate).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserCode).IsModified = true;
                dbEntry.Property(s => s.ModifiedUserID).IsModified = true;
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }


        #endregion
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
