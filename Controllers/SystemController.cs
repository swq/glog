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
using System.Data.Entity;
namespace gLog_FrontEnd.Controllers
{
    public class SystemController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();
        //
        // GET: /System/
        [AdminLayout]
        public ActionResult ChangePwd()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckPwd(string Old_Pwd, string New_Pwd)
        {
            var Userinfo = Session["User"] as T_Auth_User;
            var New_Pwd_MD5 = FormsAuthentication.HashPasswordForStoringInConfigFile(New_Pwd, "MD5").ToLower();
            var Old_Pwd_MD5 = FormsAuthentication.HashPasswordForStoringInConfigFile(Old_Pwd, "MD5").ToLower();
            var user = db.T_Auth_User.AsNoTracking().FirstOrDefault(
                s => s.LoginName == Userinfo.LoginName
                    && s.LoginPwd == Old_Pwd_MD5);
            var re = "success";
            if (user == null)
                re = "fail";
            else
            {
                var User = new T_Auth_User { Id = Userinfo.Id, LoginPwd = New_Pwd_MD5 };
                DbEntityEntry<T_Auth_User> dbEntry = db.Entry<T_Auth_User>(User);
                dbEntry.State =  EntityState.Unchanged;
                dbEntry.Property(s => s.LoginPwd).IsModified = true;
                db.SaveChanges();
            }
            return Json(new { status = re }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignOut()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Login", "T_Auth_User");
        }
    }
}
