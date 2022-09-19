using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.Xml;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CheckoutTourUsersController : Controller
    {

        #region Declartion
        IRepository<TbCheckoutTourUser> _repCheckoutTourUser;
        IRepository<TbTour> _repTour;

        List<TbTour> _TbTousrs;
        List<TbCheckoutTourUser> _TbCheckoutTourUsers;
        TbCheckoutTourUser _TbCheckoutTourUser;
        #endregion

        #region Ctor

        public CheckoutTourUsersController(IRepository<TbCheckoutTourUser> repCheckoutTourUser, IRepository<TbTour> repTour)
        {
            _TbTousrs = new List<TbTour>();
            _TbCheckoutTourUsers = new List<TbCheckoutTourUser>();
            _TbCheckoutTourUser = new TbCheckoutTourUser();
            _repCheckoutTourUser = repCheckoutTourUser;
              _repTour=repTour;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbCheckoutTourUsers = (await _repCheckoutTourUser.GetAll()).OrderByDescending(a=>a.Id).ToList();
            _TbTousrs = await _repTour.GetAll();
            _TbCheckoutTourUsers.ForEach(  a => a.TbTour = _TbTousrs.FirstOrDefault(z=>z.Id==a.TourId));
             
            return View(_TbCheckoutTourUsers);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbCheckoutTourUser = await _repCheckoutTourUser.GetById(id);
            return View(_TbCheckoutTourUser);
        }

      

        #endregion
    }
}
