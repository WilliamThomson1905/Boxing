using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int ID { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        public string Mobile { get; set; }


        // Has their account be hidden from other users/not admin? T: Yes -- F: No
        public bool AccountHidden { get; set; }

        public ApplicationUser()
        {
            AccountHidden = true; 
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class GeneralUser : ApplicationUser
    {
        public SkillLevel SkillLevel { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public char Gender { get; set; }

    }

    public enum SkillLevel
    {
        // Novice, (Advanced) Beginner, Competent, Proficient, Expert.
        NOVICE, BEGINNER, COMPETENT, PROFICIENT, EXPERT
    }



    /// <summary>
    /// The Trainers in the gym - each will instanciate this class 
    /// </summary>
    public class TrainerUser : ApplicationUser
    {
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        public string Instagarm { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }

    }

    /// <summary>
    /// The Staff class will be used to store data for the following users: 
    ///     Administrators, Staff. 
    /// </summary>
    public class Staff : ApplicationUser
    {
        public Staff() { }
    }


    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }
        public float Price { get; set; }


        // Foriegn key 
        public int SupplierID { get; set; }
        // Corresponding navigation property 
        public virtual Supplier Supplier { get; set; }

    }

    // Supplier of Equipment 
    public class Supplier
    {
        // Primary Key
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }

        // Navigation property - Suppliers can provide multiple instances of 'Equipment' 
        public virtual ICollection<Equipment> Equipments { get; set; }

    }



}