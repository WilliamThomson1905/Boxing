using BoxingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using BoxingSite.DAL;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace BoxingSite.Controllers
{
    public class BoxerController : Controller
    { 

        private ApplicationDbContext context = new ApplicationDbContext();


        public ActionResult Boxers()
        {
            ViewBag.Title = "Trainers";
            ViewBag.Message = "Your Management/Trainers description page.";

            return View(context.BoxerUsers.ToList().Where(m => m.AccountHidden == false));
        }


        // GET: Trainer/Details/id
        public ActionResult BoxerDetails(string id)
        {
            //if (id.HasValue())
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            BoxerUser boxer = context.BoxerUsers.Find(id);
            if (boxer == null)
            {
                return HttpNotFound();
            }


            SingleBoxerViewmodel sbvm = new SingleBoxerViewmodel()
            {
                Id = boxer.Id,
                Description = boxer.Description,
                Forename = boxer.Forename,
                Surname = boxer.Surname,
                ImageSrc = boxer.ImageSrc,
                Instagram = boxer.Instagram,
                LinkedIn = boxer.LinkedIn,
                Facebook = boxer.Facebook,
                Twitter = boxer.Twitter,
                Email = boxer.Email,
                Available = boxer.Available
            };

            return View(sbvm);
        }

        // GET: Trainer/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }
        


        // GET: Trainer/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxerUser boxer = context.BoxerUsers.Find(id);
            if (boxer == null)
            {
                return HttpNotFound();
            }
            return View(boxer);
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Title, DOB, Description,Forename,Surname,ImageSrc,Mobile,Instagram, " +
            "LinkedIn, Facebook, Twitter, Email, Available")] BoxerUser boxerUser)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var boxer = context.BoxerUsers.Find(boxerUser.Id);

                    boxer.Title = boxerUser.Title;
                    boxer.DOB = boxerUser.DOB;
                    boxer.Description = boxerUser.Description;
                    boxer.Forename = boxerUser.Forename;
                    boxer.Surname = boxerUser.Surname;
                    boxer.ImageSrc = boxerUser.ImageSrc;
                    boxer.Mobile = boxerUser.Mobile;
                    boxer.Instagram = boxerUser.Instagram;
                    boxer.LinkedIn = boxerUser.LinkedIn;
                    boxer.Facebook = boxerUser.Facebook;
                    boxer.Twitter = boxerUser.Twitter;
                    boxer.Email = boxerUser.Email;
                    boxer.Available = boxerUser.Available;


                    context.Entry(boxer).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("BoxerDetails", "Boxer", new { id = boxer.Id });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("Boxers", "Boxer");

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            try
            {
                BoxerUser boxerUser = context.BoxerUsers.Find(id);
                context.BoxerUsers.Remove(boxerUser);
                context.SaveChanges();
                return RedirectToAction("Boxers", "Boxer");

            }
            catch
            {
                return RedirectToAction("Boxers", "Boxer");
            }
        }



        // DELETE: /Trainer/DeleteUser/id
        [Authorize(Roles = "Administrator")]
        #region public ActionResult DeleteUser(string Id)
        public ActionResult DeleteUser(string Id)
        {

            try
            {
                BoxerUser boxerUser = context.BoxerUsers.Find(Id);
                context.BoxerUsers.Remove(boxerUser);
                context.SaveChanges();
                return RedirectToAction("Boxers", "Boxer");

            }
            catch
            {
                return RedirectToAction("Boxers", "Boxer");
            }

        }
        #endregion



    }
}
