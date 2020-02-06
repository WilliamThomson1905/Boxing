using BoxingSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoxingSite.Models;
using System.Data.Entity;
using System.Net;

namespace BoxingSite.Controllers
{
    public class SupplierController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();


        // GET: Prices
        public ActionResult Supplier()
        {
            ViewBag.Message = "Your Supplier page.";
            return View(context.Suppliers.ToList());
        }




        // GET: Equipment/CreateCreateEquipment
        public ActionResult CreateSupplier()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSupplier([Bind(Include = "Name, Mobile")] Supplier pSupplier)
        {
            if (ModelState.IsValid)
            {
                Supplier newSupplier = context.Suppliers.Find(pSupplier.SupplierID);

                Supplier supplier = new Supplier
                {
                    Name = pSupplier.Name,
                    Mobile = pSupplier.Mobile
                  
                };

                // add and save the  new insyance to the context
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                return RedirectToAction("Supplier", "Supplier");
            }

            return View(pSupplier);
        }




        public ActionResult EditSupplier(int? Id)
        {

            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            

            Supplier supplier = context.Suppliers.Find(Id);

            if (supplier == null)
                return HttpNotFound();
            

            return View(supplier);
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupplier([Bind(Include = "SupplierID, Name, Mobile")] Supplier pSupplier)
        {
            if (ModelState.IsValid)
            {
                Supplier supplier = context.Suppliers.Find(pSupplier.SupplierID);
                supplier.Name = pSupplier.Name;
                supplier.Mobile = pSupplier.Mobile;

                context.Entry(supplier).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Supplier");
            }


            return View(pSupplier);
        }





        // DELETE: /Supplier/DeleteSupplier/id
        [Authorize(Roles = "Administrator")]
        #region public ActionResult DeleteSupplier(int Id)
        public ActionResult DeleteSupplier(int Id)
        {
             
            try
            {
                Supplier supplier = context.Suppliers.Find(Id);
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
                return RedirectToAction("Supplier", "Supplier");

            }
            catch
            {
                return RedirectToAction("Supplier", "Supplier");
            }

        }
        #endregion



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }










    }
}
