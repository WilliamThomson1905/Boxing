﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BoxingSite.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;

namespace BoxingSite.DAL
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userStore = new UserStore<ApplicationUser>(context);

            //_____________________________________________________________________
            //populating the Role table - Administrator
            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_STAFF))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_STAFF));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_TRAINER))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_TRAINER));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_GENERAL))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_GENERAL));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_SUSPENDED))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
            }


            //_________________________________________________________________
            // Seeding an Admin user

            string userName = "admin@test.com";
            string password = "Password_1";
            //  var passwordHash = new PasswordHasher();
            //  password = passwordHash.HashPassword(password);

            var user = userManager.FindByName(userName);

            if (user == null)
            {
                var newUser = new Staff()
                {
                    Forename = "Robert",
                    Surname = "Lilt",
                    DOB = new DateTime(1964, 7, 9),
                    Title = "Mr",
                    PhoneNumber = "01418920828",
                    Mobile = "07418920828",
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true

                };
                
                userManager.Create(newUser, password);
                userManager.AddToRole(newUser.Id, RoleNames.ROLE_ADMINISTRATOR);
            }


            var generalUsers = new List<GeneralUser>
            {
                new GeneralUser {
                    UserName ="1@test.com",
                    Email ="1@test.com",
                    Forename ="Carson",
                    Surname ="Alexander",
                    DOB = new DateTime(1964, 7, 9),
                    Weight =14.4F,
                    Height =201,
                    Gender ='M',
                    SkillLevel = SkillLevel.BEGINNER
                },
                new GeneralUser {
                    UserName ="2@test.com",
                    Email ="2@test.com",
                    Forename ="Meredith",
                    Surname ="Alonso",
                    DOB = new DateTime(1964, 7, 9),
                    Weight =10.4F,
                    Height =181,
                    Gender ='F',
                    SkillLevel =SkillLevel.NOVICE
                },
                new GeneralUser {
                    UserName ="3@test.com",
                    Email = "3@test.com",
                    Forename ="Arturo",
                    Surname ="Anand",
                    DOB = new DateTime(1964, 7, 9),
                    Weight =8.2F,
                    Height =125,
                    Gender ='F',
                    SkillLevel =SkillLevel.BEGINNER
                },
                new GeneralUser {
                    UserName ="4@test.com",
                    Email = "4@test.com",
                    Forename ="Gytis",
                    Surname ="Barzdukas",
                    DOB = new DateTime(1964, 7, 9),
                    Weight =14.4F,
                    Height =201,
                    Gender ='M',
                    SkillLevel =SkillLevel.COMPETENT
                },
                new GeneralUser {
                    UserName ="5@test.com",
                    Email = "5@test.com",
                    Forename ="Nino",
                    Surname ="Olivetto",
                    DOB = new DateTime(1964, 7, 9),
                    Weight =14.4F,
                    Height =201,
                    Gender ='M',
                    SkillLevel =SkillLevel.PROFICIENT}
            };

            foreach (var person in generalUsers)
            {              
                string generalPassword = "Password_1";
                userManager.Create(person, generalPassword);
                userManager.AddToRole(person.Id, RoleNames.ROLE_GENERAL);
            }


            //generalUsers.ForEach(s => context.GeneralUsers.Add(s));
            context.SaveChanges();


            // Seed trainers/coaches
            var trainerUsers = new List<TrainerUser>
            {
                new TrainerUser {
                    UserName ="6@test.com",
                    Email = "6@test.com",
                    ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg",
                    Forename = "Robert",
                    Surname = "Pitch",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = false,
                    Description = "Cat‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser {
                    UserName ="7@test.com",
                    Email = "7@test.com",
                    ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg",
                    Forename = "John",
                    Surname = "Greenleaf",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Dog‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="8@test.com",
                    Email = "8@test.com",
                    ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg",
                    Forename = "Helen",
                    Surname = "Tacki",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Elephant‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="9@test.com",
                    Email = "9@test.com",
                    ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg",
                    Forename = "Garry",
                    Surname = "Gates",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Banana‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="10@test.com",
                    Email = "10@test.com",
                    ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg",
                    Forename = "Douglas",
                    Surname = "Butcher",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Tree‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="11@test.com",
                    Email = "11@test.com",
                    ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg",
                    Forename = "James",
                    Surname = "Walker",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Usurp‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="12@test.com",
                    Email = "12@test.com",
                    ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg",
                    Forename = "William",
                    Surname = "Wallace",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="13@test.com",
                    Email = "13@test.com",
                    ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",
                    Forename = "Elizabeth",
                    Surname = "Almond",
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="14@test.com",
                    Email = "14@test.com",
                    ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",
                    Forename = "Robert",
                    Surname = "Lilt",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="15@test.com",
                    Email = "15@test.com",
                    ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg",
                    Forename = "Violet",
                    Surname = "Malcolm",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },


                new TrainerUser {
                    UserName ="16@test.com",
                    Email = "16@test.com",
                    ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg",
                    Forename = "Robert",
                    Surname = "Pitch",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = false,
                    Description = "Cat‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="17@test.com",
                    Email = "17@test.com",
                    ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg",
                    Forename = "John",
                    Surname = "Greenleaf",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Dog‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="18@test.com",
                    Email = "18@test.com",
                    ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg",
                    Forename = "Helen",
                    Surname = "Tacki",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Elephant‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="19@test.com",
                    Email = "19@test.com",
                    ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg",
                    Forename = "Garry",
                    Surname = "Gates",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Banana‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="20@test.com",
                    Email = "20@test.com",
                    ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg",
                    Forename = "Douglas",
                    Surname = "Butcher",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Tree‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="21@test.com",
                    Email = "21@test.com",
                    ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg",
                    Forename = "James",
                    Surname = "Walker",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Usurp‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="22@test.com",
                    Email = "22@test.com",
                    ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg",
                    Forename = "William",
                    Surname = "Wallace",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="23@test.com",
                    Email = "23@test.com",
                    ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",
                    Forename = "Elizabeth",
                    Surname = "Almond",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="24@test.com",
                    Email = "24@test.com",
                    ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",
                    Forename = "Robert",
                    Surname = "Lilt",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="25@test.com",
                    Email = "25@test.com",
                    ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg",
                    Forename = "Violet",
                    Surname = "Malcolm",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },



                new TrainerUser {
                    UserName ="26@test.com",
                    Email = "26@test.com",
                    ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg",
                    Forename = "Robert",
                    Surname = "Pitch",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = false,
                    Description = "Cat‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="27@test.com",
                    Email = "27@test.com",
                    ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg",
                    Forename = "John",
                    Surname = "Greenleaf",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Dog‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="28@test.com",
                    Email = "28@test.com",
                    ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg",
                    Forename = "Helen",
                    Surname = "Tacki",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Elephant‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="29@test.com",
                    Email = "29@test.com",
                    ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg",
                    Forename = "Garry",
                    Surname = "Gates",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Banana‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="30@test.com",
                    Email = "30@test.com",
                    ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg",
                    Forename = "Douglas",
                    Surname = "Butcher",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Tree‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="31@test.com",
                    Email = "31@test.com",
                    ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg",
                    Forename = "James",
                    Surname = "Walker",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "Usurp‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="32@test.com",
                    Email = "32@test.com",
                    ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg",
                    Forename = "William",
                    Surname = "Wallace",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="33@test.com",
                    Email = "33@test.com",
                    ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",
                    Forename = "Elizabeth",
                    Surname = "Almond",
                    DOB = new DateTime(1964, 7, 9),
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = false,
                    Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                },
                new TrainerUser {
                    UserName ="34@test.com",
                    Email = "34@test.com",
                    ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",
                    Forename = "Robert",
                    Surname = "Lilt",
                    Instagarm = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    LinkedIn = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Facebook = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Twitter = "https://www.youtube.com/watch?v=OJxCcCEobNs",
                    Available = true,
                    Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."
                }

            };

            foreach (var person in trainerUsers)
            {
                string generalPassword = "Password_1";
                userManager.Create(person, generalPassword);
                userManager.AddToRole(person.Id, RoleNames.ROLE_TRAINER);
            }


            // trainerUsers.ForEach(s => context.TrainerUsers.Add(s));
            context.SaveChanges();
            







        }
    }
}


