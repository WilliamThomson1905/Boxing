﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BoxingSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
  
        public string Title { get; set; }

        [Required]
        [StringLength(20)]
        public string Forename { get; set; }

        [Required]
        [StringLength(20)]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Phone]
        public string Mobile { get; set; }

        [Compare(nameof(Mobile), ErrorMessage = "Mobile number doesn't match.")]
        public string RepeatMobile { get; set; }


        // Has their account be hidden from other users/not admin? T: Yes -- F: No
        public bool AccountHidden { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            EmailConfirmed = false;
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
    [Table("GeneralUser")]
    public class GeneralUser : ApplicationUser
    {
        [Display(Name = "Skill Level")]
        public SkillLevel SkillLevel { get; set; }

        [Display(Name = "Weight-pounds")]
        public float Weight { get; set; }

        [Display(Name = "Height-In feet")]
        public float Height { get; set; }
        public bool Gender { get; set; }

    }

    public enum SkillLevel
    {
        // Novice, (Advanced) Beginner, Competent, Proficient, Expert.
        NOVICE, BEGINNER, COMPETENT, PROFICIENT, EXPERT
    }



    /// <summary>
    /// The Trainers in the gym - each will instanciate this class 
    /// </summary> 
    [Table("TrainerUser")]
    public class TrainerUser : ApplicationUser
    {

        [Required]
        [StringLength(1500)]
        public string Description { get; set; }


        public string ImageSrc { get; set; }

        [Url]
        public string Instagram { get; set; }

        [Url]
        public string Facebook { get; set; }

        [Url]
        public string LinkedIn { get; set; }

        [Url]
        public string Twitter { get; set; }

        // for PT Sessions - will bew shown on their Trainer/Details/id view
        [Display(Name = "Are you open for PT Sessions?")]
        public bool Available { get; set; }

    }

    /// <summary>
    /// The Staff class will be used to store data for the following users: 
    ///     Administrators, Staff. 
    /// </summary>
    [Table("Staff")]
    public class Staff : ApplicationUser
    {
        public Staff() { }
    }

    [Table("Equipment")]
    public class Equipment
    {
        public int EquipmentID { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }
        public float Price { get; set; }


        // Foriegn key 
        public int SupplierID { get; set; }
        // Corresponding navigation property 
        public virtual Supplier Supplier { get; set; }

    }

    // Supplier of Equipment 
    [Table("Supplier")]
    public class Supplier
    {
        // Primary Key
        public int SupplierID { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Phone]
        public string Mobile { get; set; }

        // Navigation property - Suppliers can provide multiple instances of 'Equipment' 
        public virtual ICollection<Equipment> Equipments { get; set; }

    }

    // Classes  
    [Table("BoxingClass")]
    public class BoxingClass
    {
        // Primary Key
        public int BoxingClassID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        // Navigation property - BoxingClass can have one or more instances of 'Schedule' 
        public virtual ICollection<Schedule> Schedule { get; set; }

 
    }

    // When an BoxingClass is created 
    [Table("Schedule")]
    public class Schedule
    {
        public int ScheduleID { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        public Day Day { get; set; }

        public ClassStatus ClassStatus { get; set; }

        // Foriegn key - Trainer will do class
        public int BoxingClassID { get; set; }
        // Corresponding navigation property 
        public virtual BoxingClass BoxingClass { get; set; }

        // Foriegn key - Trainer will do class
        public string TrainerID { get; set; }
        // Corresponding navigation property 
        public virtual TrainerUser Trainer { get; set; }
        



        public Schedule()
        {
            ClassStatus = ClassStatus.AVAILABLE;
        }
    }

    public enum ClassStatus
    {
        AVAILABLE, FULLYBOOKED, CANCELLED
    }

    public enum Day
    {
        // Novice, (Advanced) Beginner, Competent, Proficient, Expert.
        MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY
    }



}