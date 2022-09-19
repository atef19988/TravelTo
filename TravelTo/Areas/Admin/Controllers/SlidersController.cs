using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SlidersController : Controller
    {

        #region Declartion
        IRepository<TbSlider> _repSlider;


        List<TbSlider> _TbSliders;
        TbSlider _TbSlider;
        #endregion

        #region Ctor

        public SlidersController(IRepository<TbSlider> repSlider)
        {
            _repSlider = repSlider;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbSliders = await _repSlider.GetAll();
            return View(_TbSliders);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbSlider = await _repSlider.GetById(id);
            return View(_TbSlider);
        }

        // GET: HomeController/Create
        public IActionResult Create()
        {
            _TbSlider = new TbSlider();
            return View(_TbSlider);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbSlider tbSlider,List<IFormFile> files)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tbSlider);
                }
                else
                tbSlider.ImageName = HelperMethod.UploadFileName(files, @"Admin\Uploads", ".jpg");

                await _repSlider.Add(tbSlider);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbSlider);
            }
        }

        // GET: HomeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            _TbSlider = await _repSlider.GetById(id);
            return View(_TbSlider);

        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbSlider tbSlider)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(tbSlider);
                else
                    await _repSlider.Update(tbSlider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbSlider);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repSlider.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _repSlider.GetById(id));
            }
        }

        #endregion
    }
}
