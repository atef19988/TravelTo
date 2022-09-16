using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Controllers
{
   
    public class CheckoutTourUsersController : Controller
    {

        #region Declartion
        IRepository<TbCheckoutTourUser> _repCheckoutTourUser;


        List<TbCheckoutTourUser> _TbCheckoutTourUsers;
        TbCheckoutTourUser _TbCheckoutTourUser;
        #endregion

        #region Ctor

        public CheckoutTourUsersController(IRepository<TbCheckoutTourUser> repCheckoutTourUser)
        {
            _repCheckoutTourUser = repCheckoutTourUser;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbCheckoutTourUsers = await _repCheckoutTourUser.GetAll();
            return View(_TbCheckoutTourUsers);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbCheckoutTourUser = await _repCheckoutTourUser.GetById(id);
            return View(_TbCheckoutTourUser);
        }

        // GET: HomeController/Create
        public IActionResult Create(int id)
        {
            _TbCheckoutTourUser = new TbCheckoutTourUser();
            _TbCheckoutTourUser.TourId= id;
            return View(_TbCheckoutTourUser);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbCheckoutTourUser tbCheckoutTourUser)
        {
            try
            {  
                if (!ModelState.IsValid)
                {
                    return View(tbCheckoutTourUser);
                }
                else
                 await _repCheckoutTourUser.Add(tbCheckoutTourUser);

                return RedirectToAction(nameof(Index),"Home");
            }
            catch
            {
                return View(tbCheckoutTourUser);
            }
        }

        // GET: HomeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            _TbCheckoutTourUser = await _repCheckoutTourUser.GetById(id);
            return View(_TbCheckoutTourUser);

        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbCheckoutTourUser tbCheckoutTourUser)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(tbCheckoutTourUser);
                else
                    await _repCheckoutTourUser.Update(tbCheckoutTourUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbCheckoutTourUser);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repCheckoutTourUser.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _repCheckoutTourUser.GetById(id));
            }
        }

        #endregion
    }
}
