using InsuranceAggregator.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InsuranceAggregator.Models;

namespace UserAuthApp.Controllers
{
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
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var output = new ErrorModel();
            output.Title = "Register";
            if (!string.IsNullOrEmpty(model.Email)&&model.Password.Equals(model.ConfirmPassword))
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    output.ErrorMessage = "Registration Complete";
                    output.ErrorCode = 1;
                    return RedirectToAction("Responce",output);
                }
                var count = result.Errors.Count();

               if (count > 1) { 
                foreach (var error in result.Errors)
                {
                    output.ErrorMessage =   error.Description;
                    output.ErrorCode = 2;
                    return RedirectToAction("Responce", output);

                }
                }   
            }
            output.ErrorCode = 2;
            return RedirectToAction("Responce", output);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var item = "title";
            ViewBag.Title = item;
            return View();
        }
        public IActionResult Responce(ErrorModel response)
        {
            var Data = new AccountViweModel(response.Title, response.ErrorMessage, response.ErrorCode);           
            return View("Responce");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
