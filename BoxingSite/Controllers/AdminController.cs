using BoxingSite.DAL;
using BoxingSite.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;
using PagedList;


namespace BoxingSite.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        // GET: Prices
        #region public ActionResult Users(string searchStringUserNameOrEmail)
        public ActionResult Users(string searchStringUserNameOrEmail, string currentFilter, int? page)
        {
            try
            {
                int intPage = 1;
                int intPageSize = 6; // Will only display six users per page
                int intTotalPageCount = 0;  

                if (searchStringUserNameOrEmail != null)
                {
                    intPage = 1;
                }
                else
                {
                    if (currentFilter != null)
                    {
                        searchStringUserNameOrEmail = currentFilter;
                        intPage = page ?? 1; // If page doesn't have a value, default to 1
                    }
                    else
                    {
                        searchStringUserNameOrEmail = ""; 
                        intPage = page ?? 1;
                    }
                }

                ViewBag.CurrentFilter = searchStringUserNameOrEmail;


                List<ExpandedUserDTO> col_UserDTO = new List<ExpandedUserDTO>();


                int intSkip = (intPage - 1) * intPageSize;

                // Retrieving count of all the users that email and/or username match the user search value. 
                intTotalPageCount = UserManager.Users
                    .Where(x => x.UserName.Contains(searchStringUserNameOrEmail))
                    .Count();

                // Retrieving a list of users that match the search criteria and the ordering by username
                var result = UserManager.Users
                    .Where(x => x.UserName.Contains(searchStringUserNameOrEmail))
                    .OrderBy(x => x.UserName)
                    .Skip(intSkip)
                    .Take(intPageSize)
                    .ToList();


                // Looping through all users and getting their requested values for output. 
                foreach (var item in result)
                {

                    ExpandedUserDTO objUserDTO = new ExpandedUserDTO();

                    objUserDTO.Title = item.Title;
                    objUserDTO.Forename = item.Forename;
                    objUserDTO.Surname = item.Surname;
                    objUserDTO.DOB = item.DOB;
                    objUserDTO.Mobile = item.Mobile;
                    objUserDTO.Email = item.Email;
                    objUserDTO.UserName = item.UserName;

                    objUserDTO.PhoneNumber = item.PhoneNumber;
                    objUserDTO.LockoutEndDateUtc = item.LockoutEndDateUtc;


                    // Get all rolenames that correspond to each user. 
                    // This will be used to display their current accout status: suspended or active.
                    var user = UserManager.FindByName(searchStringUserNameOrEmail);
                    ICollection<UserRolesDTO> colUserRoleDTO = (from objRole in UserManager.GetRoles(item.Id)
                        select new UserRolesDTO
                        {
                            RoleName = objRole

                        }).ToList();
                        

                    objUserDTO.Roles = colUserRoleDTO;
                    col_UserDTO.Add(objUserDTO);
                }

                // Set the number of pages
                var _UserDTOAsIPagedList = new StaticPagedList<ExpandedUserDTO>( col_UserDTO, intPage, intPageSize, intTotalPageCount );

                return View(_UserDTOAsIPagedList);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex);
                List<ExpandedUserDTO> col_UserDTO = new List<ExpandedUserDTO>();

                return View(col_UserDTO.ToPagedList(1, 25));
            }
        }
        #endregion




        #region public ApplicationUserManager UserManager
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                    HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();  // if _userManager desn't have a value then call getUserManager
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

    }
}
