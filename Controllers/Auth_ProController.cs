using gLog_FrontEnd.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class Auth_ProController : Controller
    {
        // GET: Auth_Pro
        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }

    }
}
