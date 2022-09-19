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

    public class SettingsController : Controller
    {

        #region Declartion
        IRepository<TbSettings> _repSettings;


        List<TbSettings> _TbSettingss;
        TbSettings _TbSettings;
        #endregion

        #region Ctor

        public SettingsController(IRepository<TbSettings> repSettings)
        {
            _repSettings = repSettings;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbSettingss = await _repSettings.GetAll();
            return View(_TbSettingss);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbSettings = await _repSettings.GetById(id);
            return View(_TbSettings);
        }

        // GET: HomeController/Create
        public IActionResult Create()
        {
            _TbSettings = new TbSettings();
            return View(_TbSettings);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbSettings tbSettings,List<IFormFile> filesIamge, List<IFormFile> filesLogo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tbSettings);
                }
                else
                tbSettings.ImageName = HelperMethod.UploadFileName(filesIamge, @"Admin\Uploads", ".jpg");
                tbSettings.Logo = HelperMethod.UploadFileName(filesLogo, @"Admin\Uploads", ".jpg");
                await _repSettings.Add(tbSettings);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbSettings);
            }
        }

        // GET: HomeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            _TbSettings = await _repSettings.GetById(id);
            return View(_TbSettings);

        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbSettings tbSettings)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(tbSettings);
                else
                    await _repSettings.Update(tbSettings);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbSettings);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repSettings.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _repSettings.GetById(id));
            }
        }

        #endregion
    }
}
