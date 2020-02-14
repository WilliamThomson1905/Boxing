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
    public class TrainerController : Controller
    {
        //List<TrainerUser> trainers = new List<TrainerUser>
        //    {
        //        new TrainerUser { ID =1, ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "Cat‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =2, ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "Dog‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =3, ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "Elephant‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =4, ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "Banana‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =5, ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "Tree‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =6, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "Usurp‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =7, ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =8, ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =9, ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =10, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

        //        new TrainerUser { ID =11, ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =12, ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =13, ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =14, ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =15, ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =16, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =17, ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =18, ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =19, ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =20, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

        //        new TrainerUser { ID =21, ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =22, ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =23, ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =24, ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =25, ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =26, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =27, ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =28, ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
        //        new TrainerUser { ID =29, ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."}


        //    };


        private ApplicationDbContext context = new ApplicationDbContext();


        public ActionResult Trainers()
        {
            ViewBag.Title = "Trainers";
            ViewBag.Message = "Your Management/Trainers description page.";

            return View(context.TrainerUsers.ToList().Where(m => m.AccountHidden == false));
        }


        // GET: Trainer/Details/id
        public ActionResult TrainerDetails(string id)
        {
            //if (id.HasValue())
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            TrainerUser trainer = context.TrainerUsers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }


            SingleTrainerViewmodel stvm = new SingleTrainerViewmodel()
            {
                Id = trainer.Id,
                Description = trainer.Description,
                Forename = trainer.Forename,
                Surname = trainer.Surname,
                ImageSrc = trainer.ImageSrc,
                Instagram = trainer.Instagram,
                LinkedIn = trainer.LinkedIn,
                Facebook = trainer.Facebook,
                Twitter = trainer.Twitter,
                Email = trainer.Email,
                Available = trainer.Available
            };

            return View(stvm);
        }

        // GET: Trainer/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Trainer/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerUser trainer = context.TrainerUsers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Title, DOB, Description,Forename,Surname,ImageSrc,Mobile,Instagram, " +
            "LinkedIn, Facebook, Twitter, Email, Available")] TrainerUser trainerUser)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var trainer = context.TrainerUsers.Find(trainerUser.Id);
                    trainer.Title = trainerUser.Title;
                    trainer.DOB = trainerUser.DOB;
                    trainer.Description = trainerUser.Description;
                    trainer.Forename = trainerUser.Forename;
                    trainer.Surname = trainerUser.Surname;
                    trainer.ImageSrc = trainerUser.ImageSrc;
                    trainer.Mobile = trainerUser.Mobile;
                    trainer.Instagram = trainerUser.Instagram;
                    trainer.LinkedIn = trainerUser.LinkedIn;
                    trainer.Facebook = trainerUser.Facebook;
                    trainer.Twitter = trainerUser.Twitter;
                    trainer.Email = trainerUser.Email;
                    trainer.Available = trainerUser.Available;


                    context.Entry(trainer).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("TrainerDetails", "Trainer", new { id = trainer.Id });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("Trainers", "Trainer");

        }

        // GET: Trainer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}




        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            try
            {
                TrainerUser trainerUser = context.TrainerUsers.Find(id);
                context.TrainerUsers.Remove(trainerUser);
                context.SaveChanges();
                return RedirectToAction("Trainers", "Trainer");

            }
            catch
            {
                return RedirectToAction("Trainers", "Trainer");
            }
        }



        // DELETE: /Trainer/DeleteUser/id
        [Authorize(Roles = "Administrator")]
        #region public ActionResult DeleteUser(string Id)
        public ActionResult DeleteUser(string Id)
        {

            try
            {
                TrainerUser trainerUser = context.TrainerUsers.Find(Id);
                context.TrainerUsers.Remove(trainerUser);
                context.SaveChanges();
                return RedirectToAction("Trainers", "Trainer");

            }
            catch
            {
                return RedirectToAction("Trainers", "Trainer");
            }

        }
        #endregion



    }
}
