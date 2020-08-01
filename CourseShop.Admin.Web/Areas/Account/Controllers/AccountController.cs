using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Admin.Core.Entities;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Admin.Web.Areas.Account.Controllers
{
    [Area("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Home" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                if(user == null)
                { 
                    return RedirectToAction("Index"); 
                }
                var roles = await _userManager.GetRolesAsync(user);
                if(!roles.Any(r => r.Contains("admin")))
                {
                    return RedirectToAction("Index");
                }
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
