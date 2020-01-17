using BoxingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxingSite.Controllers
{
    public class TrainerController : Controller
    {
        List<TrainerUser> trainers = new List<TrainerUser>
            {
                new TrainerUser { T_Id ="1", ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="2", ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="3", ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="4", ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="5", ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="6", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="7", ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="8", ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="9", ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="10", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

                new TrainerUser { T_Id ="11", ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="12", ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="13", ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="14", ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="15", ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="16", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="17", ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="18", ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="19", ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="20", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

                new TrainerUser { T_Id ="21", ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="22", ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="23", ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="24", ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="25", ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="26", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="27", ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="28", ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { T_Id ="29", ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."}


            };

        public ActionResult Trainers()
        {
            ViewBag.Message = "Your Management/Trainers description page.";

            return View("Trainers", trainers);
        }

        // GET: Trainer/Details/5
        public ActionResult TrainerDetails(string id)
        {
            TrainerUser trainer = new TrainerUser();
            trainer = trainers.Find(item => item.T_Id.Equals(id));

            SingleTrainerViewmodel stvm = new SingleTrainerViewmodel()
            {
                Description = trainer.Description,
                Forename = trainer.Forename,
                Surname = trainer.Surname,
                ImageSrc = trainer.ImageSrc
            };

            return View(stvm);
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
