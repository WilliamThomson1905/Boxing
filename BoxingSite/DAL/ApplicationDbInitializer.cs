using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BoxingSite.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

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
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_TRAINER))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_GENERAL))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_SUSPENDED))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
            }


            //_________________________________________________________________
            //_________________________________________________________________

            string userName = "admin@test.com";
            string password = "Password_1";

            //  var passwordHash = new PasswordHasher();
            //  password = passwordHash.HashPassword(password);

            //create Admin user and role

            var user = userManager.FindByName(userName);
            if (user == null)
            {
                var newUser = new GeneralUser()
                {
                    Forename = "Robert",
                    Surname = "Lilt",
                    DOB = new DateTime(1964, 7, 9),
                    Title = "Mr",
                    Gender = 'M',
                    PhoneNumber = "01418920828",
                    Mobile = "07418920828",
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true



                };


                //userManager.Create(newUser, password);
                //userManager.AddToRole(newUser, RoleNames.ROLE_ADMINISTRATOR);
                userManager.Create(newUser, password);
                //userManager.SetLockoutEnabled(newUser.Id, true);
                userManager.AddToRole(newUser.Id, RoleNames.ROLE_ADMINISTRATOR);
            }


            var generalUsers = new List<GeneralUser>
            {
                new GeneralUser{ UserName="Carson@test.com",  Forename="Carson",Surname="Alexander", Weight=14.4F, Height=201, Gender='M', SkillLevel=SkillLevel.BEGINNER },
                new GeneralUser{UserName="Meredith@test.com",Forename="Meredith",Surname="Alonso", Weight=10.4F, Height=181, Gender='F', SkillLevel=SkillLevel.NOVICE},
                new GeneralUser{UserName="Arturo@test.com",Forename="Arturo",Surname="Anand", Weight=8.2F, Height=125, Gender='F', SkillLevel=SkillLevel.BEGINNER},
                new GeneralUser{UserName="Gytis@test.com",Forename="Gytis",Surname="Barzdukas", Weight=14.4F, Height=201, Gender='M', SkillLevel=SkillLevel.COMPETENT},
                new GeneralUser{UserName="Yan@test.com",Forename="Yan",Surname="Li", Weight=14.4F, Height=201, Gender='M', SkillLevel=SkillLevel.BEGINNER},
                new GeneralUser{UserName="Peggy@test.com",Forename="Peggy",Surname="Justice", Weight=14.4F, Height=201, Gender='F', SkillLevel=SkillLevel.EXPERT},
                new GeneralUser{UserName="Laura@test.com", Forename="Laura",Surname="Norman", Weight=14.4F, Height=201, Gender='M', SkillLevel=SkillLevel.BEGINNER},
                new GeneralUser{UserName="Nino@test.com",Forename="Nino",Surname="Olivetto", Weight=14.4F, Height=201, Gender='M', SkillLevel=SkillLevel.PROFICIENT}
            };

            generalUsers.ForEach(s => context.GeneralUsers.Add(s));
            context.SaveChanges();



            var trainerUsers = new List<TrainerUser>
            {
                new TrainerUser { UserName="Robert1@test.com", ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "Cat‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="John@test.com", ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "Dog‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Helen@test.com", ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "Elephant‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Garry@test.com", ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "Banana‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Douglas@test.com", ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "Tree‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="1@test.com", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "Usurp‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="2@test.com", ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="3@test.com", ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="4@test.com", ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="5@test.com", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

                new TrainerUser { UserName="6@test.com", ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="7@test.com", ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="8@test.com", ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="9@test.com", ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Car9son@test.com", ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="C8arson@test.com", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Car7son@test.com", ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Car76son@test.com", ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Cars6on@test.com", ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Ca5rson@test.com", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "Violet", Surname = "Malcolm", Description = "J‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},

                new TrainerUser { UserName="Ca4rson@test.com", ImageSrc ="../../images/trainers/joshua-medway-sd-Pq5aDoO4-unsplash.jpg", Forename = "Robert", Surname = "Pitch", Description = "A‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Car3son@test.com", ImageSrc ="../../images/trainers/colin-cassidy-akj4oRw8E04-unsplash.jpg", Forename = "John", Surname = "Greenleaf", Description = "B‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Cars2on@test.com", ImageSrc ="../../images/trainers/steven-van-vLC--gwHnbQ-unsplash.jpg", Forename = "Helen", Surname = "Tacki", Description = "C‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Cars1on@test.com", ImageSrc ="../../images/trainers/emily-sea-coiWR0gT8Cw-unsplash.jpg", Forename = "Garry", Surname = "Gates", Description = "D‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Car0son@test.com", ImageSrc ="../../images/trainers/filipe-almeida-mnEWC72eWDM-unsplash.jpg", Forename = "Douglas", Surname = "Butcher", Description = "E‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Car312son@test.com", ImageSrc ="../../images/trainers/form-B6fw69UttOI-unsplash.jpg", Forename = "James", Surname = "Walker", Description = "F‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Ca33rson@test.com", ImageSrc ="../../images/trainers/form-qQGAQMbURhU-unsplash.jpg", Forename = "William", Surname = "Wallace", Description = "G‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Car333son@test.com", ImageSrc ="../../images/trainers/imani-clovis-tBt9JxuQBYs-unsplash.jpg",Forename = "Elizabeth", Surname = "Almond", Description = "H‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."},
                new TrainerUser { UserName="Carso333n@test.com", ImageSrc ="../../images/trainers/jonathan-cosens-photography-jcp-v-YiCIbDjOQ-unsplash.jpg",Forename = "Robert", Surname = "Lilt", Description = "I‘The Baby Faced Assassin’ Shelly Sweeney fought her way to national champion and represented her country proving she has those winning qualities needed to be a champion. Though boxing has been her passion, she is turning her hand to the coaching side of the sport, to help people grow in confidence and get the best out of themselves as she personally took up the sport for those reasons and knows the benefits first hand. Never judge a book by its cover, this angelic face will push you to your limits."}
            };

            trainerUsers.ForEach(s => context.TrainerUsers.Add(s));
            context.SaveChanges();

            

        }
    }
}

//var roleStore = new RoleStore<IdentityRole>(context);
//var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
//var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
//var userStore = new UserStore<ApplicationUser>(context);

//            //_____________________________________________________________________
//            //populating the Role table - Administrator
//            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
//            {
//                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
//            }
//            if (!roleManager.RoleExists(RoleNames.ROLE_STAFF))
//            {
//                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
//            }
//            if (!roleManager.RoleExists(RoleNames.ROLE_TRAINER))
//            {
//                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
//            }
//            if (!roleManager.RoleExists(RoleNames.ROLE_GENERAL))
//            {
//                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
//            }

//            if (!roleManager.RoleExists(RoleNames.ROLE_SUSPENDED))
//            {
//                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_SUSPENDED));
//            }


//            ////////////////////////////////////////////////////////////
//            ///

//            //_________________________________________________________________
//            //_________________________________________________________________

//            string userName = "admin@admin.com";
//string password = "Password_1";

////  var passwordHash = new PasswordHasher();
////  password = passwordHash.HashPassword(password);

////create Admin user and role

//var user = userManager.FindByName(userName);
//            if (user == null)
//            {
//                var newUser = new Staff()
//                {
//                    Forename = "Robert",
//                    Surname = "Lilt",
//                    DOB = new DateTime(1964, 7, 9),
//                    Title = "Mr",
//                    PhoneNumber = "01418920828",
//                    Mobile = "07418920828",
//                    UserName = userName,
//                    Email = userName,
//                    EmailConfirmed = true



//                };


////userManager.Create(newUser, password);
////userManager.AddToRole(newUser, RoleNames.ROLE_ADMINISTRATOR);
//userManager.Create(newUser, password);
//                //userManager.SetLockoutEnabled(newUser.Id, true);
//                userManager.AddToRole(newUser.Id, RoleNames.ROLE_ADMINISTRATOR);
//            }



//            base.Seed(context);
//context.SaveChanges();