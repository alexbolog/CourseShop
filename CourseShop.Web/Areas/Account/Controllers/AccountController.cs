using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Business.ViewModels;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Areas.Account.Controllers
{
    [Area("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, viewModel.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home", new { area = "Home" });
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterAccountViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register");
            }
            var applicationUser = viewModel.ToApplicationUser();
            var result = await _userManager.CreateAsync(applicationUser, viewModel.Password);
            if(result.Succeeded)
            {
                return View("Login");
            }

            var newModel = new RegisterAccountViewModel();
            newModel.ErrorMessages = result.Errors.Select(e => e.Description);
            return View(newModel);
        }


    }
}
