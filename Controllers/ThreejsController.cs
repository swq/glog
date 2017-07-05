using gLog_FrontEnd.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class ThreejsController : Controller
    {

        // GET: Threejs
        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult Geometry()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult TextGeometry()
        {
            return View(); 
        }
        [AdminLayout]
        public ActionResult Material()
        {
            return View(); 
        }
        [AdminLayout]
        public ActionResult Mesh()
        {
            return View();
        }
        [AdminLayout]
        public ActionResult Animation()
        {
            return View();
        }
    }
}
