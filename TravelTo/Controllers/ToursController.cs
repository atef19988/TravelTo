using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;
using TravelTo.Models;

namespace TravelTo.Controllers
{
    public class ToursController : Controller
    {
        #region Declartion
        IRepository<TbTour> _repTour; 
        List<TbTour> _TbTours;
        TbTour _TbTour;
   
        #endregion

        #region Ctor
        public ToursController(IRepository<TbTour> repTour,  IRepository<TbSlider> repSlider )
        {
             _repTour = repTour;
    
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbTours = (await _repTour.GetAll()).ToList(); 
            return View(_TbTours);

        }
        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbTour = await _repTour.GetById(id);
            return View(_TbTour);
        }

        #endregion
    }
}