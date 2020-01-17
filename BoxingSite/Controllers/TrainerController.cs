using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxingSite.Controllers
{
    public class TrainerController : Controller
    {

        public ActionResult Trainers()
        {
            ViewBag.Message = "Your Management/Trainers description page.";

            return View();
        }

        // GET: Trainer/Details/5
        public ActionResult TrainerDetails(int id)
        {
            return View();
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trainer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
