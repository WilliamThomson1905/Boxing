using BoxingSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxingSite.Controllers
{
    public class EquipmentController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();


        // GET: Prices
        public ActionResult Equipment()
        {
            ViewBag.Message = "Your Equipment page.";
            return View(context.Equipment.ToList());
        }




        
    }
}
