using Data_Hospital_Manager.Entities;
using Hospital_Manager.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Manager.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signIn;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signIn, UserManager<User> userManager)
        {
            this.signIn = signIn;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //   // var res=await signIn.PasswordSignInAsync()
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
