using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelTo.Controllers
{
    public class UserController : Controller
    {
        UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register()
        {

            //_userManager.CreateAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
