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

        public ActionResult Trainers()
        {
            ViewBag.Message = "Your Management/Trainers description page.";

            return View();
        }

        public ActionResult Schedule()
        {
            ViewBag.Message = "Your Schedule page.";

            return View();
        }

        public ActionResult Prices()
        {
            ViewBag.Message = "Your Prices page.";

            return View();
        }

     
    }
}