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
    public class AboutController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();


        // GET: Prices
        public ActionResult About()
        {
            ViewBag.Message = "Your About/Equiptment page.";
            return View(context.Equipment.ToList());
        }




        // GET: Equipment/CreateCreateEquipment
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateEquipment()
        {
            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateEquipment([Bind(Include = "Name, Description, " +
            "Quantity, PurchaseDate, Price, SupplierId ")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                Supplier chosenSupplier = context.Suppliers.Find(equipment.SupplierID);

                Equipment equip = new Equipment
                {
                    Description = equipment.Description,
                    Name = equipment.Name,
                    Price = equipment.Price,
                    Quantity = equipment.Quantity,
                    PurchaseDate = equipment.PurchaseDate,
                    Supplier = chosenSupplier,
                    SupplierID = chosenSupplier.SupplierID
                };

                context.Equipment.Add(equip);
                context.SaveChanges();
                return RedirectToAction("About", "About");
            }

            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "Name");
            return View(equipment);
        }



        [Authorize(Roles = "Administrator")]
        public ActionResult EditEquipment(int? Id)
        {

            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Equipment equipment = context.Equipment.Find(Id);


            if (equipment == null)
            {
                return HttpNotFound();
            }


            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "Name", equipment.SupplierID);
            return View(equipment);
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditEquipment([Bind(Include = "EquipmentID,Name, Description, Quantity, PurchaseDate, Price, SupplierId")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                var chosenSupplier = context.Suppliers.Find(equipment.SupplierID);


                var equip = new Equipment()
                {
                    Description = equipment.Description,
                    Name = equipment.Name,
                    EquipmentID = equipment.EquipmentID,
                    Price = equipment.Price,
                    Quantity = equipment.Quantity,
                    PurchaseDate = equipment.PurchaseDate,
                    SupplierID = equipment.SupplierID,
                    Supplier = chosenSupplier
                };


                context.Entry(equip).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("About");
            }

            ViewBag.SupplierId = new SelectList(context.Suppliers, "SupplierId", "Name", equipment.SupplierID);
            return View(equipment);
        }





        // DELETE: /Equipment/DeleteEquipment/id
        [Authorize(Roles = "Administrator")]
        #region public ActionResult DeleteEquipment(int Id)
        public ActionResult DeleteEquipment(int Id)
        {
             
            try
            {
                Equipment equipment = context.Equipment.Find(Id);
                context.Equipment.Remove(equipment);
                context.SaveChanges();
                return RedirectToAction("About", "About");

            }
            catch
            {
                return RedirectToAction("About", "About");
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
