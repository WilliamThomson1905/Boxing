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
    public class ScheduleController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: BoxingClass
        public ActionResult Index()
        {

            //monday classes
            var monday = from day1 in context.Schedule
                         where day1.Day == Day.MONDAY
                         orderby day1.StartTime
                         select day1;

            var tuesday = from day2 in context.Schedule
                         where day2.Day == Day.TUESDAY
                         orderby day2.StartTime
                         select day2;

            var wednesday = from day3 in context.Schedule
                         where day3.Day == Day.WEDNESDAY
                         orderby day3.StartTime
                         select day3;

            var thursday = from day4 in context.Schedule
                          where day4.Day == Day.THURSDAY
                          orderby day4.StartTime
                          select day4;

            var friday = from day5 in context.Schedule
                         where day5.Day == Day.FRIDAY
                         orderby day5.StartTime
                         select day5;

            var saturday = from day6 in context.Schedule
                          where day6.Day == Day.SATURDAY
                          orderby day6.StartTime
                          select day6;

            var sunday = from day7 in context.Schedule
                         where day7.Day == Day.SUNDAY
                         orderby day7.StartTime
                         select day7;
           

            ScheduleListsViewmodel slvm = new ScheduleListsViewmodel()
            {
                Monday = monday.ToList(),
                Tuesday = tuesday.ToList(),
                Wednesday = wednesday.ToList(),
                Thursday = thursday.ToList(),
                Friday = friday.ToList(),
                Saturday = saturday.ToList(),
                Sunday = sunday.ToList(),
            };




            // var boxingClasses = context.BoxingClasses.Include(b => b.Trainer, c => c.Schedule);
            //return View(context.BoxingClasses.ToList());
            return View(slvm);
        }



        // GET: BoxingClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxingClass boxingClass = context.BoxingClasses.Find(id);
            if (boxingClass == null)
            {
                return HttpNotFound();
            }
            return View(boxingClass);
        }

        // GET: BoxingClass/Create
        public ActionResult Create()
        {
            ViewBag.TrainerID = new SelectList(context.Users, "Id", "Title");
            return View();
        }

        // POST: BoxingClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoxingClassID,Title,Description,TrainerID")] BoxingClass boxingClass)
        {
            if (ModelState.IsValid)
            {
                context.BoxingClasses.Add(boxingClass);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrainerID = new SelectList(context.Users, "Id", "Title", boxingClass.TrainerID);
            return View(boxingClass);
        }

        // GET: BoxingClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxingClass boxingClass = context.BoxingClasses.Find(id);
            if (boxingClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainerID = new SelectList(context.Users, "Id", "Title", boxingClass.TrainerID);
            return View(boxingClass);
        }

        // POST: BoxingClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoxingClassID,Title,Description,TrainerID")] BoxingClass boxingClass)
        {
            if (ModelState.IsValid)
            {
                context.Entry(boxingClass).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrainerID = new SelectList(context.Users, "Id", "Title", boxingClass.TrainerID);
            return View(boxingClass);
        }

        // GET: BoxingClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxingClass boxingClass = context.BoxingClasses.Find(id);
            if (boxingClass == null)
            {
                return HttpNotFound();
            }
            return View(boxingClass);
        }

        // POST: BoxingClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxingClass boxingClass = context.BoxingClasses.Find(id);
            context.BoxingClasses.Remove(boxingClass);
            context.SaveChanges();
            return RedirectToAction("Index");
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
