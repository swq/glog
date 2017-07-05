using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class CNYD_STRUCT_TREEController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();
        // GET: CNYD_SYS_TA_TREE
        [AdminLayout]
        public ActionResult Index()
        {
            //db.CNYD_SYS_TA_TREE.Add(new CNYD_SYS_TA_TREE
            //{
            //    TA_KEY_ = "C001",
            //    TA_NAME_ = "1层",
            //    TA_TYPEID = 0,
            //    PARENT_ID_ = 5,
            //    IS_LEAF_ = true,
            //    IS_AUTO_EXPAND_ = false,
            //    ICON_NAME_ = "",
            //    SORT_NO_ = 0,
            //    PJ_ID_ = "598fcba58a71423b8cb47c9d31f5840e",
            //    IsDeleted = false,
            //    Enable = true,
            //    Note = "1层",
            //    TA_NAME_EN = "floor0001"
            //});
            //db.SaveChanges();
            return View();
        }
        [AdminLayout]
        public ActionResult TA_StructIndex()
        {
            return View();
        }
        public JsonResult GetTA_Struct(string PJ_ID_)
        {
            var data = db.CNYD_STRUCT_TREE
                .Where(s => s.IsDeleted == false && s.Enable == true && s.PJ_ID_ == PJ_ID_)
                .OrderBy(s => s.SORT_NO_)
                .Select(s => new {
                    id = s.ID_,
                    s.IS_LEAF_,
                    pId =  s.PARENT_ID_,
                    s.SORT_NO_,
                    name = s.STRUCT_NAME_,
                    isParent = s.PARENT_ID_ == null? true : false,
                    title = s.STRUCT_KEY_,
                    s.STRUCT_NAME_EN,
                    s.STRUCT_TYPEID,
                    s.Note
                });
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProInfo()
        {
            var data = db.CNYD_B_PROJECT.Where(s => s.RECDELETED_ == false )
                .Select(s => new {
                    id = s.ID_,
                    text = s.PJ_NAME_CN_
                });
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNode(int ID)
        {
            var data = db.CNYD_STRUCT_TREE.Where(s => s.ID_ == ID && s.IsDeleted == false && s.Enable == true)
                        .Select(s => new {
                            s.ID_,
                            s.STRUCT_KEY_,
                            s.STRUCT_NAME_,
                            s.STRUCT_NAME_EN,
                            s.STRUCT_TYPEID,
                            s.SORT_NO_,
                            s.IS_LEAF_,
                            s.Enable,
                            s.Note
                        }).FirstOrDefault();
                        
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(string data)
        {
            var User = Session["User"] as T_Auth_User;
            var STRUCT = JsonConvert.DeserializeObject<CNYD_STRUCT_TREE>(data);
            if (STRUCT.ID_ == -1)
            {
                STRUCT.IsDeleted = false;
                STRUCT.CreateDate = DateTime.Now;
                STRUCT.CreateUserCode = User.LoginName;
                STRUCT.CreateUserID = User.Id;
                db.CNYD_STRUCT_TREE.Add(STRUCT);
            }
            else {
                var Entity = db.CNYD_STRUCT_TREE.AsNoTracking().FirstOrDefault(t => t.ID_ == STRUCT.ID_);
                Entity.ModifiedUserID = User.Id;
                Entity.ModifiedDate = DateTime.Now;
                Entity.STRUCT_KEY_ = STRUCT.STRUCT_KEY_;
                Entity.STRUCT_NAME_ = STRUCT.STRUCT_NAME_;
                Entity.STRUCT_NAME_EN = STRUCT.STRUCT_NAME_EN;
                Entity.STRUCT_TYPEID = STRUCT.STRUCT_TYPEID;
                Entity.SORT_NO_ = STRUCT.SORT_NO_;
                Entity.Note = STRUCT.Note;
                Entity.Enable = STRUCT.Enable;
                Entity.IS_LEAF_ = STRUCT.IS_LEAF_;
                db.Entry(Entity).State = EntityState.Unchanged;
                db.Entry(Entity).Property(t => t.ModifiedUserID).IsModified = true;
                db.Entry(Entity).Property(t => t.ModifiedDate).IsModified = true;
                db.Entry(Entity).Property(t => t.STRUCT_KEY_).IsModified = true;
                db.Entry(Entity).Property(t => t.STRUCT_NAME_).IsModified = true;
                db.Entry(Entity).Property(t => t.STRUCT_NAME_EN).IsModified = true;
                db.Entry(Entity).Property(t => t.STRUCT_TYPEID).IsModified = true;
                db.Entry(Entity).Property(t => t.ModifiedUserID).IsModified = true;
                db.Entry(Entity).Property(t => t.SORT_NO_).IsModified = true;
                db.Entry(Entity).Property(t => t.Note).IsModified = true;
                db.Entry(Entity).Property(t => t.Enable).IsModified = true;
                db.Entry(Entity).Property(t => t.IS_LEAF_).IsModified = true;
            }
            var Msg = db.SaveChanges() > 0 ? "success" : "fail";
            return Json(new { Msg = Msg }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var User = Session["User"] as T_Auth_User;
            var Entity = db.CNYD_STRUCT_TREE.AsNoTracking().FirstOrDefault(t => t.ID_ == ID);
            Entity.ModifiedUserID = User.Id;
            Entity.ModifiedDate = DateTime.Now;
            Entity.IsDeleted = true;
            db.Entry(Entity).State = EntityState.Unchanged;
            db.Entry(Entity).Property(t => t.IsDeleted).IsModified = true;
            var Msg = db.SaveChanges() > 0 ? "success" : "fail";
            return Json(new { Msg = Msg }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTA_List(string PJ_ID,int STRUCT_TREE_ID)
        {
            var Left = db.T_TA_Info.Where(s => s.PJ_ID == PJ_ID && s.IsDeleted == false && s.Enable == true);
            var Right = db.T_TA_STRUCT.Where(s => s.STRUCT_TREE_ID == STRUCT_TREE_ID);
            var data1 = (from l in Left
                         join l1 in Right on l.ID equals l1.T_TA_Info into temps
                        from temp in temps.DefaultIfEmpty()
                        select new
                        {
                            TA_ID = l.ID,
                            TA_Code = l.TA_Code,
                            TA_TYPE = l.TA_TYPE,
                            Floors = l.Floors,
                            Note = l.Note,
                            Note_EN = l.Note_EN,
                            IsCheck = temp.STRUCT_TREE_ID != null ? true : false
                        });
            var data = data1.ToList();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
