using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationToursController : Controller
    {

        #region Declartion
        IRepository<TbLocationTour> _repLocationTour;


        List<TbLocationTour> _TbLocationTours;
        TbLocationTour _TbLocationTour;
        #endregion

        #region Ctor

        public LocationToursController(IRepository<TbLocationTour> repLocationTour)
        {
            _repLocationTour = repLocationTour;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbLocationTours = await _repLocationTour.GetAll();
            return View(_TbLocationTours);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbLocationTour = await _repLocationTour.GetById(id);
            return View(_TbLocationTour);
        }

        // GET: HomeController/Create
        public IActionResult Create()
        {
            _TbLocationTour = new TbLocationTour();
            return View(_TbLocationTour);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbLocationTour tbLocationTour,List<IFormFile> files)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tbLocationTour);
                }
                else
                tbLocationTour.ImageName = HelperMethod.UploadFileName(files, @"Admin\Uploads", ".jpg");

                await _repLocationTour.Add(tbLocationTour);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbLocationTour);
            }
        }

        // GET: HomeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            _TbLocationTour = await _repLocationTour.GetById(id);
            return View(_TbLocationTour);

        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbLocationTour tbLocationTour)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(tbLocationTour);
                else
                    await _repLocationTour.Update(tbLocationTour);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbLocationTour);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repLocationTour.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _repLocationTour.GetById(id));
            }
        }

        #endregion
    }
}
