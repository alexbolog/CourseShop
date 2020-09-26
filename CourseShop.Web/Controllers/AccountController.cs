using System.Security.Claims;
using System.Threading.Tasks;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Business.ViewModels;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index(bool registrationSuccessful = false)
        {
            ViewBag.IsRegistrationSuccessful = registrationSuccessful;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var user = await userManager.FindByEmailAsync(accountViewModel.Email);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName, accountViewModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var appUser = GetApplicationUserForRegister(accountViewModel);
            var registrationResult = await userManager.CreateAsync(appUser, accountViewModel.Password);
            if (!registrationResult.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", new { registrationSuccessful = true });
        }

        private ApplicationUser GetApplicationUserForRegister(AccountViewModel accountViewModel)
        {
            return new ApplicationUser
            {
                UserName = accountViewModel.Email.Split('@')[0],
                Email = accountViewModel.Email,
                FirstName = accountViewModel.FirstName,
                LastName = accountViewModel.LastName
            };
        }

    }
}
