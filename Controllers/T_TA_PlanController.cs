using gLog_FrontEnd.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class T_TA_PlanController : Controller
    {
        // GET: T_TA_Plan
        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult SJ()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult CG()
        {
            return View();
        }
    }
}
