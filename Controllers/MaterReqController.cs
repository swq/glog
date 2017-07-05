using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace gLog_FrontEnd.Controllers
{
    public class MaterReqController : Controller
    {
        gLog_FrontEndContext db = new gLog_FrontEndContext();

        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(Nullable<int> TA_ID)
        {
            if (TA_ID == null)
            {
                return Json(new {Msg = "null"}, JsonRequestBehavior.AllowGet);
            }
            var Flag = db.Set<CNYD_STRUCT_TREE>().AsNoTracking().FirstOrDefault(s => s.ID_ == TA_ID).MAT_STATUS;
            var Data = db.T_BT_INFO.AsNoTracking().Where(s => s.TA_ID == TA_ID && s.IsDelete == false).ToList();
            return Json(new { Msg = "null",Data = Data,Flag = Flag }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(string AddJson,string ChangeJson, string DeleteJson)
        {
            var Userinfo = Session["User"] as T_Auth_User;
            //添加
            if (!string.IsNullOrEmpty(AddJson))
            {
                var Add = JsonConvert.DeserializeObject<List<T_BT_INFO>>(AddJson);
                for (int i = 0; i< Add.Count;i++)
                {
                    Add[i].CreateUserID = Userinfo.Id;
                    Add[i].CreateDate = DateTime.Now;
                    Add[i].IsDelete = false;
                }
                db.T_BT_INFO.AddRange(Add);
            }
            //删除
            if (!string.IsNullOrEmpty(DeleteJson))
            {
                var Delete = JsonConvert.DeserializeObject<List<T_BT_INFO>>(DeleteJson);
                Delete.ForEach(s =>
                {
                    var Entity = db.T_BT_INFO.AsNoTracking().FirstOrDefault(t => t.ID == s.ID);
                    if (Entity != null)
                    {
                        Entity.IsDelete = true;
                        Entity.ModifiedUserID = Userinfo.Id;
                        Entity.ModifiedDate = DateTime.Now;
                        db.Entry(Entity).State = EntityState.Unchanged;
                        db.Entry(Entity).Property(t => t.IsDelete).IsModified = true;
                        db.Entry(Entity).Property(t => t.ModifiedUserID).IsModified = true;
                        db.Entry(Entity).Property(t => t.ModifiedDate).IsModified = true;
                    }
                });

            }
            //修改
            if (!string.IsNullOrEmpty(ChangeJson))
            {
                var Change = JsonConvert.DeserializeObject<List<T_BT_INFO>>(ChangeJson);
                Change.ForEach(s => {
                    var Entity = db.T_BT_INFO.AsNoTracking().FirstOrDefault(t => t.ID == s.ID);  
                    Entity.BT_Code = s.BT_Code;
                    Entity.Comments = s.Comments;
                    Entity.Description_CN = s.Description_CN;
                    Entity.Description_EN = s.Description_EN;
                    Entity.Dimension = s.Dimension;
                    Entity.Drawing = s.Drawing;
                    Entity.Qty = s.Qty;
                    Entity.Specification = s.Specification;
                    Entity.Units = s.Units;
                    Entity.ListNO = s.ListNO;
                    Entity.TA_CODE = s.TA_CODE;
                    Entity.TA_DES = s.TA_DES;
                    Entity.ModifiedUserID = Userinfo.Id;
                    Entity.ModifiedDate = DateTime.Now;
                    Entity.BTType = s.BTType;
                    db.Entry(Entity).State = EntityState.Unchanged;
                    db.Entry(Entity).Property(t => t.BT_Code).IsModified = true;
                    db.Entry(Entity).Property(t => t.Description_EN).IsModified = true;
                    db.Entry(Entity).Property(t => t.Description_CN).IsModified = true;
                    db.Entry(Entity).Property(t => t.Units).IsModified = true;
                    db.Entry(Entity).Property(t => t.Qty).IsModified = true;
                    db.Entry(Entity).Property(t => t.Drawing).IsModified = true;
                    db.Entry(Entity).Property(t => t.Comments).IsModified = true;
                    db.Entry(Entity).Property(t => t.Dimension).IsModified = true;
                    db.Entry(Entity).Property(t => t.Specification).IsModified = true;
                    db.Entry(Entity).Property(t => t.ModifiedUserID).IsModified = true;
                    db.Entry(Entity).Property(t => t.ModifiedDate).IsModified = true;
                    db.Entry(Entity).Property(t => t.ListNO).IsModified = true;
                    db.Entry(Entity).Property(t => t.TA_CODE).IsModified = true;
                    db.Entry(Entity).Property(t => t.TA_DES).IsModified = true;
                    db.Entry(Entity).Property(t => t.BTType).IsModified = true;
                });
            }
            var ChangeCount = db.SaveChanges();
            var mess = ChangeCount > 0 ? "Success" : "Fail";
            return Json(new { mess = mess },JsonRequestBehavior.AllowGet);
        }

        public JsonResult Flag (Nullable<int> TA_ID)
        {
            var Entity = db.Set<CNYD_STRUCT_TREE>().AsNoTracking().FirstOrDefault(s => s.ID_ == TA_ID);
            Entity.MAT_STATUS = true;
            db.Entry(Entity).State = EntityState.Unchanged;
            db.Entry(Entity).Property(s => s.MAT_STATUS).IsModified = true;

            var ChangeCount = db.SaveChanges();
            var MES = ChangeCount > 0 ? "Success" : "Fail";
            return Json(new { MES = MES }, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}