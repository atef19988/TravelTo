using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelTo.Areas.Admin.Models;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    
    public class HomeController : Controller
    {

        #region Declartion
        IRepository<TbTour> _repTour;
        IRepository<TbCheckoutTourUser> _repCheckoutTourUser;
        List<TbCheckoutTourUser> _TbCheckoutTourUser;
        List<TbTour> _TbTours;
 
        ModelAdminHome _ModelHome;
        #endregion

        #region Ctor
        public HomeController(IRepository<TbTour> repTour, IRepository<TbCheckoutTourUser> repCheckoutTourUser)
        {
            _ModelHome=new ModelAdminHome();
            _repTour =repTour;  
            _repCheckoutTourUser= repCheckoutTourUser;
    }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbTours = (await _repTour.GetAll()).Take(5).ToList();
            _ModelHome.TbTours = _TbTours ;
          
            _TbCheckoutTourUser = (await _repCheckoutTourUser.GetAll()).Take(5).ToList(); 
             _TbCheckoutTourUser.ForEach(async x => x.TbTour = await _repTour.GetById(x.TourId));

            _ModelHome.TbCheckoutTourUser = _TbCheckoutTourUser;

            return View(_ModelHome);
        }

        
        #endregion
    }
}
