using System;

namespace BoxingSite.Models
{
    public class RoleNames
    {

        // There will be three types of accounts (excluding locked/suspended): 
        //      Administrator - Creating Trainer Accounts and managing all the information throughout the system (equipment/schedule details/pricing/trainers details). 
        //      Staff         - General staff members. 
        //      Trainer/Coach - Managing there own details which will be displayed on Trainer.cshtml and their own details view (trainer/trainerDetails/id).
        //      General User  - Undecided at the moment - if I implement booking functionality, then they'll be able to do that. 

        // Admin Accounts
        public const string ROLE_ADMINISTRATOR = "Administrator";

        // Staff 
        public const string ROLE_STAFF = "Staff";

        // Trainer/Coach Accounts
        public const string ROLE_TRAINER = "Trainer";

        // General User Accounts 
        public const string ROLE_GENERAL = "General";

        // If user is to be Locked Out/suspended then assign to this Role
        public const string ROLE_SUSPENDED = "Suspended";

    }

}