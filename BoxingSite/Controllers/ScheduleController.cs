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

       
        public ActionResult Classes()
        {
            return View(context.BoxingClasses.ToList());
        }


        public ActionResult CreateBoxingClass()
        {
            // ViewBag.TrainerID = new SelectList(context.TrainerUsers, "ID", "Forename");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateBoxingClass([Bind(Include = "Title, Description")] BoxingClass pBoxingClass)
        {
            if (ModelState.IsValid)
            {
                // TrainerUser trainerDetails = context.TrainerUsers.Find(pBoxingClass.TrainerID);

                BoxingClass boxingClass = new BoxingClass
                {
                    Description = pBoxingClass.Description,
                    Title = pBoxingClass.Title
                };

                context.BoxingClasses.Add(boxingClass);
                context.SaveChanges();
                return RedirectToAction("Classes", "Schedule");
            }

            // ViewBag.ID = new SelectList(context.TrainerUsers, "ID", "Forename");
            return View("CreateBoxingClass", "Schedule");
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult EditBoxingClass(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
           BoxingClass boxingClass = context.BoxingClasses.Find(Id);

            if (boxingClass == null)
                return HttpNotFound();
            


            ViewBag.TrainerID = new SelectList(context.TrainerUsers, "ID", "Forename");
            return View(boxingClass);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditBoxingClass([Bind(Include = "BoxingClassID,Title, Description")] BoxingClass pBoxingClass)
        {
            if (ModelState.IsValid)
            {
                var chosenBoxingClass = context.BoxingClasses.Find(pBoxingClass.BoxingClassID);
                chosenBoxingClass.Title = pBoxingClass.Title;
                chosenBoxingClass.Description = pBoxingClass.Description;


                context.Entry(chosenBoxingClass).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Classes", "Schedule");
            }

            ViewBag.TrainerID = new SelectList(context.TrainerUsers, "ID", "Forename");
            return View(pBoxingClass);
        }















        // GET: BoxingClass
        public ActionResult Schedule()
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





        public ActionResult CreateSession()
        {
            ViewBag.TrainerID = new SelectList(context.TrainerUsers, "ID", "Forename");
            ViewBag.BoxingClassID = new SelectList(context.BoxingClasses, "BoxingClassID", "Title");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateSession([Bind(Include = "StartTime, EndTime, Day, ClassStatus, " +
            "BoxingClassID, TrainerID")] Schedule pSchedule)
        {
            if (ModelState.IsValid)
            {
                TrainerUser trainerDetails = context.TrainerUsers.Find(pSchedule.TrainerID);
                BoxingClass boxingClassDetails = context.BoxingClasses.Find(pSchedule.BoxingClassID);



                Schedule boxingClass = new Schedule
                {
                    StartTime = pSchedule.StartTime,
                    EndTime = pSchedule.EndTime,
                    Day = pSchedule.Day,
                    ClassStatus = pSchedule.ClassStatus,
                    TrainerID = pSchedule.TrainerID,
                    Trainer = trainerDetails,
                    BoxingClassID = pSchedule.BoxingClassID,
                    BoxingClass = boxingClassDetails
                };

                context.Schedule.Add(boxingClass);
                context.SaveChanges();
                return RedirectToAction("Schedule", "Schedule");
            }

            ViewBag.TrainerID = new SelectList(context.TrainerUsers, "ID", "Forename");
            ViewBag.BoxingClassID = new SelectList(context.BoxingClasses, "BoxingClassID", "Title");
            return View("CreateBoxingClass", "Schedule");
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult EditSession(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Schedule gymSession = context.Schedule.Find(Id);

            if (gymSession == null)
                return HttpNotFound();



            ViewBag.TrainerID = new SelectList(context.TrainerUsers, "ID", "forename");
            return View(gymSession);
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
