using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class T_TA_InfoController : Controller
    {
        gLog_FrontEndContext db = new gLog_FrontEndContext();
        // GET: T_TA_Info
        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTA_Info(string PJ_ID_)
        {
            var data = db.T_TA_Info.Where(s => s.IsDeleted == false && s.Enable == true && s.PJ_ID == PJ_ID_)
                .OrderBy(s => s.SortOrder)
                .Select(s=> new {
                    s.ID,
                    s.TA_Code,
                    s.Note_EN,
                    s.Floors,
                    s.Note,
                    s.SortOrder,
                    s.PJ_ID
                });

            return Json(new { data = data}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(string AddJson, string ChangeJosn, string DeleteJson)
        {
            //添加
            if (!string.IsNullOrEmpty(AddJson))
            {
                var Add = JsonConvert.DeserializeObject<List<T_TA_Info>>(AddJson);
                db.T_TA_Info.AddRange(Add);
            }
            ////删除
            //if (!string.IsNullOrEmpty(DeleteJson))
            //{
            //    var Delete = JsonConvert.DeserializeObject<List<T_TA_Info>>(DeleteJson);
            //    db.T_TA_Info.RemoveRange(Delete);
            //}
            ////修改
            //if (!string.IsNullOrEmpty(ChangeJosn))
            //{
            //    var Change = JsonConvert.DeserializeObject<List<T_TA_Info>>(ChangeJosn);
            //}
            var ChangeCount = db.SaveChanges();
            var mess = ChangeCount > 0 ? "Success" : "Fail";
            return Json(new { mess = mess }, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
