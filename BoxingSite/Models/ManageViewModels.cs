﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BoxingSite.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }


        [StringLength(20)]
        public string Forename { get; set; }

        [StringLength(20)]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }


        public string Mobile { get; set; }

        [Compare(nameof(Mobile), ErrorMessage = "Mobile number doesn't match.")]
        [Display(Name = "Repeat Mobile")]
        public string RepeatMobile { get; set; }


        public bool AccountHidden { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }


        // general user
        [Display(Name = "Skill Level")]
        public SkillLevel SkillLevel { get; set; }

        [Display(Name = "Weight-pounds")]
        public float Weight { get; set; }

        [Display(Name = "Height-In feet")]
        public float Height { get; set; }
        public bool Gender { get; set; }

        // trainer 
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


  
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }








    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }



    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}