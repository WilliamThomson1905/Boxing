using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BoxingSite.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BoxingSite.DAL
{   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       

        // Users 
        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<BoxerUser> BoxerUsers { get; set; }
        public DbSet<Staff> Staff { get; set; } // Also Admin 

        // Items 
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<BoxingClass> BoxingClasses { get; set; }
        public DbSet<Schedule> Schedule { get; set; }


        public DbSet<Promotion> Promotions { get; set; }



        public ApplicationDbContext() : base("ApplicationDbContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


        //}
            // base.OnModelCreating(modelBuilder);



    }
}