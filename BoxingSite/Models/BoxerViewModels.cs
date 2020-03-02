using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoxingSite.Models
{
    public class SingleBoxerViewmodel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public string Description { get; set; }
        public string ImageSrc { get; set; }

        public bool Available { get; set; }

        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }
    }

    public class CreateBoxerViewmodel
    {
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        public string Mobile { get; set; }


        public string Description { get; set; }
        public string ImageSrc { get; set; }

        // Has their account be hidden from other users/not admin? T: Yes -- F: No
        public bool DetailsHidden { get; set; }
        public bool Available { get; set; }

        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
    }
}
