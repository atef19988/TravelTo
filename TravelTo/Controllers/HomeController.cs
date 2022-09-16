using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;
using TravelTo.Models;

namespace TravelTo.Controllers
{
    public class HomeController : Controller
    {
        #region Declartion
        IRepository<TbTour> _repTour;
        IRepository<TbSlider> _repSlider;
 
        List<TbTour> _TbTours;
        List<TbSlider> _TbSlider;
        ModelHome _ModelHome;
        #endregion

        #region Ctor
        public HomeController(IRepository<TbTour> repTour,  IRepository<TbSlider> repSlider)
        {
            _ModelHome = new ModelHome();
            _repTour = repTour;
            _repSlider = repSlider;
 
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

            return View(_ModelHome);
        }


        #endregion
    }
}