using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxingSite.Controllers
{
    public class PricesController : Controller
    {
        // GET: Prices
        public ActionResult Index()
        {
            ViewBag.Message = "Your Prices page.";
            return View();
        }
        
    }
}
