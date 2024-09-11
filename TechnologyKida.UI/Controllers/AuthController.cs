using Microsoft.AspNetCore.Mvc;
using TechnologyKida.Entity;
using TechnologyKida.Repository.Interfaces;
using TechnologyKida.UI.ViewModels.UserInfoViewModels;

namespace TechnologyKida.UI.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

    
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();   
            return RedirectToAction("Login");
        }



        [HttpPost]
        public async Task<IActionResult> Login(UserInfoViewModel vm)
        {
            var userInfo= await _userRepo.GetUserInfo(vm.UserName, vm.Password);
            HttpContext.Session.SetInt32("userId", userInfo.UserId);
            HttpContext.Session.SetString("userName", userInfo.UserName);
            return RedirectToAction("Index", "Contries");
        }
        [HttpPost]
        public async Task <IActionResult> Register(UserInfoViewModel vm)
        {
            var model = new UserInfo
            {
                UserName = vm.UserName,
                Password = vm.Password
            };
            await _userRepo.RegisterUser(model);
            return RedirectToAction("Login");
        }

    }
}
