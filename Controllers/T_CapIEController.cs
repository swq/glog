using gLog_FrontEnd.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class T_CapIEController : Controller
    {
        // GET: T_CapIE
        [AdminLayout]
        public ActionResult Collect()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult Pay()
        {
            return View();
        }
    }
}