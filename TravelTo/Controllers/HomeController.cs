using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;
using TravelTo.Ef;
using TravelTo.Models;

namespace TravelTo.Controllers
{
    public class HomeController : Controller
    {
        #region Declartion
        IRepository<TbTour> _repTour;
        IRepository<TbSlider> _repSlider;
        IRepository<TbSettings> _repSetings;
        List<TbTour> _TbTours;
        List<TbSlider> _TbSlider;
        ModelHome _ModelHome;
        SignInManager<AppUserIdentity> _signInManager;
        #endregion

        #region Ctor
        public HomeController(IRepository<TbTour> repTour, IRepository<TbSettings> repSetings,  IRepository<TbSlider> repSlider, ModelHome modelHome, SignInManager<AppUserIdentity> signInManager)
        {
            _ModelHome = modelHome;
            _repTour = repTour;
            _repSlider = repSlider;
            _repSetings = repSetings;
            _signInManager = signInManager;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbTours = (await _repTour.GetAll()).Take(5).ToList();
            _ModelHome.Tours = _TbTours;
            _TbSlider = (await _repSlider.GetAll()).Take(5).ToList();
            _ModelHome.Sliders = _TbSlider;
            _ModelHome.Settings = (await _repSetings.GetAll()).FirstOrDefault();
            AppUserIdentity user=new AppUserIdentity();
            if (!string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
               user = await _signInManager.UserManager.FindByEmailAsync(HttpContext.User.Identity.Name);
            }
        if (user != null)
            {
                 
                _ModelHome.UserModel.FirstName = user.FirstName;
                _ModelHome.UserModel.LastName = user.LastName;
                _ModelHome.UserModel.Email = user.Email;
                _ModelHome.UserModel.ImageName = user.ImageName;
            }
            return View(_ModelHome);
        }


        #endregion
    }
}