using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelTo.Ef;
using TravelTo.Models;

namespace TravelTo.Controllers
{
    public class UserController : Controller
    {
        #region Declartion
        UserManager<AppUserIdentity> _userManager;
        AppUserIdentity _appUserIdentity;
        SignInManager<AppUserIdentity> _signInManager;
        #endregion


        #region Ctor
        public UserController(UserManager<AppUserIdentity> userManager, SignInManager<AppUserIdentity> signInManager)
        {
            _appUserIdentity = new AppUserIdentity();
            _userManager = userManager;
            _signInManager = signInManager; 
        } 
        #endregion
        #region Method

        public IActionResult Login()
        {
            return View(new SigninModel ());
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Login(SigninModel user)
        {
            if (!ModelState.IsValid)
                return View(user); 
            
            var result= await _signInManager.PasswordSignInAsync(user.Email,user.Pass,false,false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View(user);
        }
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel user)
        {
            if (!ModelState.IsValid)
                return View(user);
           
            else
            {
                _appUserIdentity.Email = user.Email;
                _appUserIdentity.LastName = user.LastName;
                _appUserIdentity.FirstName = user.FirstName;
                _appUserIdentity.UserName= user.Email;
            }

            var result = await _userManager.CreateAsync(_appUserIdentity,user.Pass);
            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user.Email,user.Pass , false,false); ;
            }
            else
            {
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            var x = _signInManager.UserManager.GetUserId(User);
            _signInManager.SignOutAsync();
          
            return RedirectToAction("Index","Home");
        }
        #endregion
    }
}
