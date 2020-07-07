using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoMaravillasPeru.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Pronto conocerás la experiencia de viajar dentro de un sinfín de aventuras.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Llámanos al (XXX) XXX-XXXX.";

            return View();
        }
    }
}