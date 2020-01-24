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
                new TrainerUser { ID =1, ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "Cat‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =2, ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "Dog‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =3, ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "Elephant‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =4, ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "Banana‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =5, ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "Tree‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =6, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "Usurp‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =7, ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =8, ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =9, ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =10, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

                new TrainerUser { ID =11, ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =12, ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =13, ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =14, ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =15, ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =16, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =17, ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =18, ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =19, ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =20, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

                new TrainerUser { ID =21, ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =22, ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =23, ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =24, ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =25, ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =26, ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =27, ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =28, ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { ID =29, ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."}


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
            trainer = trainers.Find(item => item.ID.Equals(id));

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
