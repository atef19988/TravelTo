using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToursController : Controller
    {

        #region Declartion
        IRepository<TbTour> _repTour;


        List<TbTour> _TbTours;
        TbTour _TbTour;
        #endregion

        #region Ctor

        public ToursController(IRepository<TbTour> repTour)
        {
            _repTour = repTour;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbTours = await _repTour.GetAll();
            return View(_TbTours);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbTour = await _repTour.GetById(id);
            return View(_TbTour);
        }

        // GET: HomeController/Create
        public IActionResult Create()
        {
            _TbTour = new TbTour();
            return View(_TbTour);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbTour tbTour,List<IFormFile> files)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tbTour);
                }
                else
                tbTour.ImageName = HelperMethod.UploadFileName(files, @"Admin\Uploads", ".jpg");

                await _repTour.Add(tbTour);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbTour);
            }
        }

        // GET: HomeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            _TbTour = await _repTour.GetById(id);
            return View(_TbTour);

        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbTour tbTour)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(tbTour);
                else
                    await _repTour.Update(tbTour);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbTour);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repTour.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _repTour.GetById(id));
            }
        }

        #endregion
    }
}
