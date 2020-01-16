using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxingSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Management()
        {
            ViewBag.Message = "Your Management description page.";

            return View();
        }

        public ActionResult Promotions()
        {
            ViewBag.Message = "Your Promotions page.";

            return View();
        }
    }
}