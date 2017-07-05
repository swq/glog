using gLog_FrontEnd.DTO;
using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace gLog_FrontEnd.Controllers
{
    public class CNYD_B_PROJECTController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();
        // GET: CNYD_B_PROJECT
        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }
        //提交创建和修改
        [HttpPost]
        public JsonResult GetEdit(string data)
        {
            var User = Session["User"] as T_Auth_User;
            var PROJECT = JsonConvert.DeserializeObject<CNYD_B_PROJECT>(data);

            if (PROJECT.ID_ == "-1")
            {
                PROJECT.ID_ = Guid.NewGuid().ToString("N");
                PROJECT.RECDELETED_ = false;
                PROJECT.RECCREATED_ = DateTime.Now; 
                PROJECT.RECCREATEDBY_ = User.LoginName;
                PROJECT.RECCREATEDBYUSRID_ = User.Id.ToString();
                db.CNYD_B_PROJECT.Add(PROJECT);
            }
            else
            {
                PROJECT.RECLASTMODIFIED_ = DateTime.Now;
                PROJECT.RECLASTMODIFIEDBY_ = User.LoginName;
                PROJECT.RECLASTMODIFIEDBYUSRID_ = User.Id.ToString();
                DbEntityEntry<CNYD_B_PROJECT> dbEntry = db.Entry<CNYD_B_PROJECT>(PROJECT);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.PJ_NUMBER_).IsModified = true;
                dbEntry.Property(s => s.PJ_NAME_YE_).IsModified = true;
                dbEntry.Property(s => s.PJ_NAME_CN_).IsModified = true;
                dbEntry.Property(s => s.PJ_MAINCONTRACTOR_).IsModified = true;
                dbEntry.Property(s => s.PJ_ARCHITECT_).IsModified = true;
                dbEntry.Property(s => s.PJ_COUNTRY_).IsModified = true;
                dbEntry.Property(s => s.PJ_TYPE_).IsModified = true;
                dbEntry.Property(s => s.PJ_STATUS_).IsModified = true;
                dbEntry.Property(s => s.RECOWNER_).IsModified = true;
                dbEntry.Property(s => s.RECLOCK_).IsModified = true;
                dbEntry.Property(s => s.PJ_STATUS_).IsModified = true;
                dbEntry.Property(s => s.SSDATE_).IsModified = true;
                dbEntry.Property(s => s.FFDATE_).IsModified = true;
                dbEntry.Property(s => s.RECLASTMODIFIED_).IsModified = true;
                dbEntry.Property(s => s.RECLASTMODIFIEDBY_).IsModified = true;
                dbEntry.Property(s => s.RECLASTMODIFIEDBYUSRID_).IsModified = true;
                dbEntry.Property(s => s.COMPANYID_).IsModified = true;
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjectInfo(int limit, int offset, string departmentname, string statu)
        {
            var ProjectInfo = (from s in db.CNYD_B_PROJECT join s1 in db.Set<TC_Company>()
                               on s.COMPANYID_ equals s1.ID where s.RECDELETED_ == false
                               select new
                               {
                                   ID_ = s.ID_,
                                   PJ_NUMBER_ = s.PJ_NUMBER_,
                                   PJ_NAME_YE_ = s.PJ_NAME_YE_,
                                   PJ_NAME_CN_ = s.PJ_NAME_CN_,
                                   PJ_COMMENTS_ = s.PJ_COMMENTS_,
                                   PJ_MAINCONTRACTOR_ = s.PJ_MAINCONTRACTOR_,
                                   PJ_ARCHITECT_ = s.PJ_ARCHITECT_,
                                   PJ_COUNTRY_ = s.PJ_COUNTRY_,
                                   PJ_TYPE_ = s.PJ_TYPE_,
                                   PJ_STATUS_ = s.PJ_STATUS_,
                                   RECAUTONR_ = s.RECAUTONR_,
                                   RECCREATED_ = s.RECCREATED_,
                                   RECCREATEDBY_ = s.RECCREATEDBY_,
                                   RECCREATEDBYUSRID_ = s.RECCREATEDBYUSRID_,
                                   RECLASTMODIFIED_ = s.RECLASTMODIFIED_,
                                   RECLASTMODIFIEDBY_ = s.RECLASTMODIFIEDBY_,
                                   RECLASTMODIFIEDBYUSRID_ = s.RECLASTMODIFIEDBYUSRID_,
                                   RECOWNER_ = s.RECOWNER_,
                                   RECLOCK_ = s.RECLOCK_,
                                   RECCHANGES_ = s.RECCHANGES_,
                                   RECDELETED_ = s.RECDELETED_,
                                   PJ_BACKENDFILE_ = s.PJ_BACKENDFILE_,
                                   PJ_PROJECTPATH_ = s.PJ_PROJECTPATH_,
                                   SAP_COMPANY_ = s.SAP_COMPANY_,
                                   SAP_DEPARTMENT_ = s.SAP_DEPARTMENT_,
                                   SAP_PRCTR_ = s.SAP_PRCTR_,
                                   SAP_PSPNR_ = s.SAP_PSPNR_,
                                   SSDATE_ = s.SSDATE_,
                                   FFDATE_ = s.FFDATE_,
                                   COMPANY = s1.Company
                               }).ToList();

            var total = ProjectInfo.Count;
            var rows = ProjectInfo.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProType()
        {
            var data = db.TC_ProjectType.Where(s => s.IsDeleted == false && s.Enable == false)
                .OrderBy(s => s.SortOrder).Select(s => new {
                    id = s.ID,text = s.PJ_Type
                }).ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProState()
        {
            //var data = db.TC_ProjectState.Where(s => s.IsDeleted == false && s.Enable == false)
            //    .OrderBy(s => s.SortOrder).Select(s => new {
            //        text= s.Note,
            //        children= new List<DTO_select2>() { new DTO_select2
            //        {
            //            id = s.ID,
            //            text = s.PJ_State
            //        } },
            //        elment= "HTMLOptGroupElement"
            //    }).ToList();
            
            var data = db.TC_ProjectState.Where(s => s.IsDeleted == false && s.Enable == false)
                        .OrderBy(s => s.SortOrder).Select(s => new
                        {
                            id = s.ID,
                            text = s.PJ_State
                        }).ToList();
            //var name = nameof(data);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        //提交删除
        [HttpPost]
        public JsonResult Del(string data)
        {
            var Projects = JsonConvert.DeserializeObject<List<CNYD_B_PROJECT>>(data);
            foreach (var temp in Projects)
            {
                temp.RECDELETED_ = true;
                db.Entry(temp).State = EntityState.Unchanged;
                db.Entry(temp).Property(s => s.RECDELETED_).IsModified = true;
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompany()
        {
            var data = db.Set<TC_Company>().Where(s => s.IsDelete == false && s.Enable == false)
                        .OrderBy(s => s.SortOrder).Select(s => new
                        {
                            id = s.ID,
                            text = s.Company
                        }).ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
