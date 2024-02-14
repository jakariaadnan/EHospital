using HospitalManagementSystem.Areas.Auth.Models;
using HospitalManagementSystem.Data.Entity;
using HospitalManagementSystem.Data.Entity.Auth;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Services.Dapper.Interfaces;
using HospitalManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Areas.Auth.Models;
using System.IO;

namespace HospitalManagementSystem.Areas.Auth.Controllers
{
    [Area("Auth")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IDapper _dapper; 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserInfoService userInfoes;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        public AccountController(IDapper dapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IUserInfoService userInfoes, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _dapper = dapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
            _env = env;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(model.Name);

                    if (user.isActive == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                    var role = await _userManager.GetRolesAsync(user);

                    List<string> userRoles = await userInfoes.UsersRoles(model.Name);

                    if (userRoles.Contains("Doctor"))
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Doctor" });
                    }
                    else if (userRoles.Contains("Patient"))
                    {
                        return RedirectToAction("Dashboard", "Home", new { Area = "Public" });
                    }
                    else if (userRoles.Contains("Admin") || userRoles.Contains("Super Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel model = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(model);
            }
            ApplicationRoleViewModel viewModel = new ApplicationRoleViewModel
            {
                roleViewModels = lstRole,
                userList = await userInfoes.GetUserList(),
                userTypes=await userInfoes.GetAllUserType()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model, string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;

            if (!string.IsNullOrEmpty(Convert.ToString(model.FullName)) &&
                !string.IsNullOrEmpty(Convert.ToString(model.PhoneNumber)) &&
                !string.IsNullOrEmpty(Convert.ToString(model.Email)) &&
                !string.IsNullOrEmpty(Convert.ToString(model.Password)) &&
                !string.IsNullOrEmpty(Convert.ToString(model.ConfirmPassword)))
            {
                try
                {
                    var webRoot = _env.WebRootPath;
                    string fileName = "";
                    int _min = 1000;
                    int _max = 9999;
                    Random _rdm = new Random();
                    int otpCode = _rdm.Next(_min, _max);

                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        FullName=model.FullName,
                        otpCode = otpCode.ToString(),
                        isVarified = 1,
                        isActive = 1,
                        createdAt = DateTime.Now,
                        isChangePassword = 1
                    };
                    try
                    {
                        string message = FileSave.SaveProfilePicture(out fileName, webRoot, model.image);
                    }
                    catch (Exception ex)
                    {

                    }
                    user.ImagePath = fileName;
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, model.RoleId);
                        return RedirectToAction("Register", "Account", new { Area = "Auth" });
                    }
                    else
                    {
                        AddErrors(result);
                    }

                    return RedirectToAction("Register", "Account", new { Area = "Auth" });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                return RedirectToAction("Register", "Account", new { Area = "Auth" });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //_logger.LogInformation("User logged out.");
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            return RedirectToAction("LogIn", "Account");
        }

        #region User Role 

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserRoleCreate()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel model = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(model);
            }
            ApplicationRoleViewModel viewModel = new ApplicationRoleViewModel
            {
                //eRPModules = await userInfoes.GetAllERPModule(),
                roleViewModels = lstRole
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserIdentityRoleCreate([FromForm] ApplicationRoleViewModel model)
        {
            var user = new ApplicationRole(model.RoleName);
            IdentityResult result = await _roleManager.CreateAsync(user);

            return RedirectToAction(nameof(UserRoleCreate));
        }

        public async Task<IActionResult> DeleteRoles(string id)
        {
            try
            {
                await userInfoes.DeleteRoleById(id);
                return Json("Success");
            }
            catch
            {
                return Json("Roles is Already Assigned Someone!!");
            }
        }

        #endregion
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}
