using gLog_FrontEnd.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class ConfrimDateController : Controller
    {
        // GET: ConfrimDate
        [AdminLayout]
        public ActionResult SJConfrim()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult CGConfrim()
        {
            return View();
        }
    }
}
