using gLog_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace gLog_FrontEnd.Controllers
{
    public class InitButtonController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();

        public JsonResult Get_InitButton(int ModuleId)
        {
            var Module = db.T_Auth_Module.AsNoTracking().Where(s => s.IsDeleted == false && s.ParentId == null)
                .Select(s => new { s.Id, s.Name, s.Code, s.Icon, s.OrderSort, s.Enabled, s.LinkUrl, s.IsMenu, s.ParentId, s.Action, s.Controller })
                .OrderBy(s => s.OrderSort)
                .ToList();
            var total = Module.Count;
            //var rows = Module.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = Module }, JsonRequestBehavior.AllowGet);
        }
    }
}