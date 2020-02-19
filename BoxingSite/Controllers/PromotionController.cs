using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoxingSite.DAL;
using BoxingSite.Models;

namespace BoxingSite.Controllers
{
    public class PromotionController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Promotion
        public ActionResult Promotions()
        {
            var listOfPromotions = context.Promotions.ToList().OrderBy(x => x.PromotionDate).Where(x => x.PromotionDate <= DateTime.Now);
            ViewBag.OldPromotions = listOfPromotions;

            return View(context.Promotions.ToList().OrderBy(x => x.PromotionDate).Where(y => y.PromotionDate >= DateTime.Now));
        }

        // GET: Promotion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotion promotion = context.Promotions.Find(id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }

        // GET: Promotion/Create
        public ActionResult CreatePromotion()
        {
            return View();
        }

        // POST: Promotion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePromotion([Bind(Include = "PromotionID,Name,PromotedBy,AboutEvent,PromotionDate, PromotionStartTime, PromotionEndTime," +
            "Photo, AmountGoing, RemainingSeats, TotalSeats," +
            "ShowMap, MapLong, MapLat," +
            "LocationBuiding, LocationStreetAddress, LocationPostCode, LocationCity")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                context.Promotions.Add(promotion);
                context.SaveChanges();
                return RedirectToAction("Promotions");
            }

            return View(promotion);
        }

        // GET: Promotion/Edit/5
        public ActionResult EditPromotion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotion promotion = context.Promotions.Find(id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }

        // POST: Promotion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPromotion([Bind(Include = "PromotionID,Name,PromotedBy,AboutEvent,PromotionDate, PromotionStartTime, PromotionEndTime," +
            "Photo, AmountGoing, RemainingSeats, TotalSeats," +
            "ShowMap, MapLong, MapLat," +
            "LocationBuiding, LocationStreetAddress, LocationPostCode, LocationCity")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                context.Entry(promotion).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Promotions");
            }
            return View(promotion);
        }


        // GET: Promotion/Delete/5
        #region public ActionResult DeletePromotion(int? Id)
        public ActionResult DeletePromotion(int? Id)
        {

            try
            {
                Promotion promotion = context.Promotions.Find(Id);
                context.Promotions.Remove(promotion);
                context.SaveChanges();
                return RedirectToAction("Promotions", "Promotion");

            }
            catch
            {
                return RedirectToAction("Promotions", "Promotion");
            }

        }
        #endregion




        // POST: Promotion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promotion promotion = context.Promotions.Find(id);
            context.Promotions.Remove(promotion);
            context.SaveChanges();
            return RedirectToAction("Promotions");
        }

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
