using gLog_FrontEnd.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        [AdminLayout]
        public ActionResult ForwardPie()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult Propressline()
        {
            return View();
        }
    }
}
