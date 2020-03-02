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
            ViewBag.Title = "Boxers";
            ViewBag.Message = "Your Management/Boxers description page.";

            return View(context.BoxerUsers.ToList());
            //return View(context.BoxerUsers.ToList().Where(m => m.DetailsHidden == false));
        }


        // GET: Boxer/Details/id
        public ActionResult BoxerDetails(int id)
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
                ID = boxer.ID,
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

        // GET: Boxer/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }
        


        // GET: Boxer/Edit/5
        public ActionResult Edit(int id)
        {
            BoxerUser boxer = context.BoxerUsers.Find(id);
            if (boxer == null)
            {
                return HttpNotFound();
            }
            return View(boxer);
        }

        // POST: Boxer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Title, DetailsHidden, DOB, Description,Forename,Surname,ImageSrc,Mobile,Instagram, " +
            "LinkedIn, Facebook, Twitter, Email, Available")] BoxerUser boxerUser)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var boxer = context.BoxerUsers.Find(boxerUser.ID);

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
                    boxer.DetailsHidden = boxerUser.DetailsHidden;


                    context.Entry(boxer).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Boxers", "Admin");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("Boxers", "Admin");

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
                return RedirectToAction("Boxers", "Admin");

            }
            catch
            {
                return RedirectToAction("Boxers", "Admin");
            }
        }



        // DELETE: /Trainer/DeleteUser/id
        [Authorize(Roles = "Administrator")]
        #region public ActionResult DeleteBoxer(int id)
        public ActionResult DeleteBoxer(int id)
        {

            try
            {
                BoxerUser boxerUser = context.BoxerUsers.Find(id);
                context.BoxerUsers.Remove(boxerUser);
                context.SaveChanges();
                return RedirectToAction("Boxers", "Admin");

            }
            catch
            {
                return RedirectToAction("Boxers", "Admin");
            }

        }
        #endregion



    }
}
