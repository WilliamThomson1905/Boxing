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
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace BoxingSite.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;



        //// GET: Get all Uesr: Staff and Admin
        //[Authorize(Roles = "Administrator")]
        //#region public ActionResult Users(string searchString)
        //public ActionResult Users(string sortOrder, string currentFilter, string searchString, int? page, string previousSort)

        //{
        //    try
        //    {
        //        if (sortOrder == null)
        //            sortOrder = "forename";

        //        ViewBag.CurrentSort = sortOrder;

        //        ViewBag.ForenameSortParm = "forename";
        //        ViewBag.SurnameSortParm = "surname";
        //        ViewBag.UsernameSortParm = "username";
        //        ViewBag.SearchStringPlaceHolder = searchString;



        //        if (searchString != null)
        //        {
        //            page = 1;
        //        }
        //        else
        //        {
        //            searchString = currentFilter;
        //        }

        //        ViewBag.CurrentFilter = searchString;


        //        var users = from s in context.Users
        //                    select s;



        //        if (!String.IsNullOrEmpty(searchString))
        //        {
        //            users = users.Where(s => s.Surname.Contains(searchString)
        //                                   || s.Forename.Contains(searchString));
        //        }

        //        switch (sortOrder)
        //        {
        //            case "forename":
        //                if (previousSort != null)
        //                {
        //                    users = users.OrderByDescending(s => s.Forename);
        //                    ViewBag.CurrentSort = null;
        //                }
        //                else
        //                {
        //                    users = users.OrderBy(s => s.Forename);
        //                    ViewBag.CurrentSort = "Forename";
        //                }

        //                break;
        //            case "surname":
        //                if (previousSort != null)
        //                {
        //                    users = users.OrderByDescending(s => s.Surname);
        //                    ViewBag.CurrentSort = null;
        //                }
        //                else
        //                {
        //                    users = users.OrderBy(s => s.Surname);
        //                    ViewBag.CurrentSort = "Surname";
        //                }
        //                break;
        //            case "username":
        //                if (previousSort != null)
        //                {
        //                    users = users.OrderByDescending(s => s.UserName);
        //                    ViewBag.CurrentSort = null;
        //                }
        //                else
        //                {
        //                    users = users.OrderBy(s => s.UserName);
        //                    ViewBag.CurrentSort = "UserName";
        //                }
        //                break;
        //            default:
        //                users = users.OrderBy(s => s.Forename);
        //                break;
        //        }

        //        int pageSize = 12;
        //        int pageNumber = (page ?? 1);
        //        return View(users.ToPagedList(pageNumber, pageSize));

        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, "Error: " + ex);
        //        List<ExpandedUserDTO> col_UserDTO = new List<ExpandedUserDTO>();

        //        return View(col_UserDTO.ToPagedList(1, 25));
        //    }
        //}
        //#endregion




        // GET: Get all Uesr: Staff and Admin
        [Authorize(Roles = "Administrator")]
        #region public ActionResult Boxers(string searchString)
        public ActionResult Boxers(string sortOrder, string currentFilter, string searchString, int? page, string previousSort)

        {
            try
            {
                if (sortOrder == null)
                    sortOrder = "forename";

                ViewBag.CurrentSort = sortOrder;

                ViewBag.ForenameSortParm = "forename";
                ViewBag.SurnameSortParm = "surname";
                ViewBag.UsernameSortParm = "username";
                ViewBag.SearchStringPlaceHolder = searchString;



                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;


                var boxers = from s in context.BoxerUsers
                            select s;



                if (!String.IsNullOrEmpty(searchString))
                {
                    boxers = boxers.Where(s => s.Surname.Contains(searchString)
                                           || s.Forename.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "forename":
                        if (previousSort != null)
                        {
                            boxers = boxers.OrderByDescending(s => s.Forename);
                            ViewBag.CurrentSort = null;
                        }
                        else
                        {
                            boxers = boxers.OrderBy(s => s.Forename);
                            ViewBag.CurrentSort = "Forename";
                        }

                        break;
                    case "surname":
                        if (previousSort != null)
                        {
                            boxers = boxers.OrderByDescending(s => s.Surname);
                            ViewBag.CurrentSort = null;
                        }
                        else
                        {
                            boxers = boxers.OrderBy(s => s.Surname);
                            ViewBag.CurrentSort = "Surname";
                        }
                        break;
                 
                    default:
                        boxers = boxers.OrderBy(s => s.Forename);
                        break;
                }

                int pageSize = 12;
                int pageNumber = (page ?? 1);
                return View(boxers.ToPagedList(pageNumber, pageSize));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex);
                List<ExpandedUserDTO> col_UserDTO = new List<ExpandedUserDTO>();

                return View(col_UserDTO.ToPagedList(1, 25));
            }
        }
        #endregion




      

        //// GET: Admin/Edit/id
        //[Authorize(Roles = "Administrator")]
        //#region public ActionResult EditUser(string UserName)
        //public ActionResult EditUser(string UserName)
        //{
        //    if (UserName == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ExpandedUserDTO objExpandedUserDTO = GetUser(UserName);

        //    if (objExpandedUserDTO == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(objExpandedUserDTO);
        //}
        //#endregion


        //// PUT: /Admin/EditUser
        //// POST: Boxer/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        //public ActionResult EditUser(ExpandedUserDTO expandedUserDTO)
        //{

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var currentEditedUser = UserManager.FindByName(expandedUserDTO.UserName);
        //            var user = context.Users.Find(currentEditedUser.Id);


        //            user.Title = expandedUserDTO.Title;
        //            user.DOB = expandedUserDTO.DOB;
        //            user.Forename = expandedUserDTO.Forename;
        //            user.Surname = expandedUserDTO.Surname;
        //            user.Mobile = expandedUserDTO.Mobile;
        //            user.RepeatMobile = user.RepeatMobile;
        //            user.Email = expandedUserDTO.Email;
        //            user.Suspended = expandedUserDTO.Suspended;


        //            context.Entry(user).State = EntityState.Modified;
        //            context.SaveChanges();
        //            return RedirectToAction("Users", "Admin");
        //        }
        //    }
        //    catch (DbUpdateException /* ex */)
        //    {
        //        //Log the error (uncomment ex variable name and write a log.
        //        ModelState.AddModelError("", "Unable to save changes. " +
        //            "Try again, and if the problem persists " +
        //            "see your system administrator.");
        //    }
        //    return RedirectToAction("Users", "Admin");

        //}




        //#region public ApplicationUserManager UserManager
        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ??
        //            HttpContext.GetOwinContext()
        //            .GetUserManager<ApplicationUserManager>();  // if _userManager desn't have a value then call getUserManager
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
        //#endregion

        //// 
        //#region private ExpandedUserDTO GetUser(string paramUserName)
        //private ExpandedUserDTO GetUser(string paramUserName)
        //{
        //    // Instanciate a new objExpandedUserDTO
        //    ExpandedUserDTO objExpandedUserDTO = new ExpandedUserDTO();

        //    // Defined as var since there are many user types.
        //    var result = UserManager.FindByName(paramUserName);

        //    // If we could not find the user, throw an exception
        //    if (result == null) throw new Exception("Could not find the User");

        //    objExpandedUserDTO.UserName = result.UserName;


        //    // Getting all the roles the searched for user has
        //    ICollection<UserRolesDTO> colUserRoleDTO = (from objRole in UserManager.GetRoles(result.Id)
        //        select new UserRolesDTO
        //        {
        //            RoleName = objRole

        //        }).ToList();


        //    objExpandedUserDTO.Forename = result.Forename;
        //    objExpandedUserDTO.Surname = result.Surname;
        //    objExpandedUserDTO.Title = result.Title;
        //    objExpandedUserDTO.DOB = result.DOB;
        //    objExpandedUserDTO.Mobile = result.Mobile;
        //    objExpandedUserDTO.RepeatMobile = result.RepeatMobile;
        //    objExpandedUserDTO.Suspended = result.Suspended;


        //    objExpandedUserDTO.Roles = colUserRoleDTO;
        //    objExpandedUserDTO.Email = result.Email;
        //    objExpandedUserDTO.LockoutEndDateUtc = result.LockoutEndDateUtc;
        //    objExpandedUserDTO.AccessFailedCount = result.AccessFailedCount;
        //    objExpandedUserDTO.PhoneNumber = result.PhoneNumber;

        //    return objExpandedUserDTO;
        //}
        //#endregion




        //#region private ExpandedUserDTO UpdateDTOUser(ExpandedUserDTO objExpandedUserDTO)
        //private ExpandedUserDTO UpdateDTOUser(ExpandedUserDTO paramExpandedUserDTO)
        //{

        //    ApplicationUser result = UserManager.FindByName(paramExpandedUserDTO.UserName);


        //    // If we could not find the user, throw an exception
        //    if (result == null)
        //    {
        //        throw new Exception("Could not find the User");
        //    }

        //    result.Email = paramExpandedUserDTO.Email;
        //    result.Forename = paramExpandedUserDTO.Forename;
        //    result.Surname = paramExpandedUserDTO.Surname;
        //    result.Title = paramExpandedUserDTO.Title;
        //    result.DOB = paramExpandedUserDTO.DOB;

        //    // Lets check if the account needs to be unlocked
        //    if (UserManager.IsLockedOut(result.Id))
        //    {
        //        // Unlock user
        //        UserManager.ResetAccessFailedCountAsync(result.Id);
        //    }

        //    UserManager.Update(result);

        //    // Was a password sent across?
        //    if (!string.IsNullOrEmpty(paramExpandedUserDTO.Password))
        //    {
        //        // Remove current password
        //        var removePassword = UserManager.RemovePassword(result.Id);
        //        if (removePassword.Succeeded)
        //        {
        //            // Add new password
        //            var AddPassword = UserManager.AddPassword(result.Id, paramExpandedUserDTO.Password);

        //            if (AddPassword.Errors.Count() > 0)
        //            {
        //                throw new Exception(AddPassword.Errors.FirstOrDefault());
        //            }
        //        }
        //    }

        //    return paramExpandedUserDTO;
        //}
        //#endregion


    }
}
