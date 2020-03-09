using System;

namespace BoxingSite.Models
{
    public class RoleNames
    {
        // There will be three types of accounts (excluding locked/suspended): 
        //      Administrator - Creating Trainer Accounts and managing all the information throughout the system (equipment/schedule details/pricing/boxers details). 
        //      Staff         - General staff members. 

        // Admin Accounts
        public const string ROLE_ADMINISTRATOR = "Administrator";

        // Staff 
        //public const string ROLE_STAFF = "Staff";

        // REMOVED role names  
        // public const string ROLE_BOXER = "Boxer";
        // public const string ROLE_GENERAL = "General";

        // If user is to be Locked Out/suspended then assign to this Role
        public const string ROLE_SUSPENDED = "Suspended";

    }

}