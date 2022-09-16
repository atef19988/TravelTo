using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelTo.Core.InterFaces;
using TravelTo.Domain.Models;

namespace TravelTo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompetitionsController : Controller
    {

        #region Declartion
        IRepository<TbCompetition> _repCompetition;


        List<TbCompetition> _TbCompetitions;
        TbCompetition _TbCompetition;
        #endregion

        #region Ctor

        public CompetitionsController(IRepository<TbCompetition> repCompetition)
        {
            _repCompetition = repCompetition;
        }
        #endregion

        #region Method

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            _TbCompetitions = await _repCompetition.GetAll();
            return View(_TbCompetitions);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _TbCompetition = await _repCompetition.GetById(id);
            return View(_TbCompetition);
        }

        // GET: HomeController/Create
        public IActionResult Create()
        {
            _TbCompetition = new TbCompetition();
            return View(_TbCompetition);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbCompetition tbCompetition,List<IFormFile> files)
        {
            try
            {



                tbCompetition.ImageName = "";
                if (!ModelState.IsValid)
                {
                    return View(tbCompetition);
                }
                else
                tbCompetition.ImageName = HelperMethod.UploadFileName(files, @"Admin\Uploads", ".jpg");
                await _repCompetition.Add(tbCompetition);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbCompetition);
            }
        }

        // GET: HomeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            _TbCompetition = await _repCompetition.GetById(id);
            return View(_TbCompetition);

        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TbCompetition tbCompetition)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(tbCompetition);
                else
                    await _repCompetition.Update(tbCompetition);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tbCompetition);
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repCompetition.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _repCompetition.GetById(id));
            }
        }

        #endregion
    }
}
