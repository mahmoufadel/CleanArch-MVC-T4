////////////////////////////////////
// generated BookLanguagesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class BookLanguagesController : Controller
    {
        private readonly ILogger<BookLanguagesController> logger;
        private readonly IServiceManager _serviceManager;

        public BookLanguagesController(IServiceManager serviceManager, ILogger<BookLanguagesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: BookLanguage
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.BookLanguageService.GetAllBookLanguage();
            return View(result.entities);
        }

        // GET BookLanguage/Details/5
        public async Task<IActionResult> Details(int? LanguageId)
        {
            var result = await _serviceManager.BookLanguageService.GetBookLanguageById(LanguageId);
            return View(result.entity);
        }

        // GET BookLanguage/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST BookLanguage/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LanguageId,LanguageCode,LanguageName,Books")] BookLanguage entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.BookLanguageService.AddBookLanguage(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get BookLanguage/Edit/5
        public async Task<IActionResult> Edit(int? LanguageId)
        {
            var result = await _serviceManager.BookLanguageService.GetBookLanguageById(LanguageId);
            return View(result.entity);
        }

        // POST BookLanguage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? LanguageId, [Bind("LanguageId,LanguageCode,LanguageName,Books")] BookLanguage entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.BookLanguageService.UpdateBookLanguage(LanguageId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get BookLanguage/Delete/5
        public async Task<IActionResult> Delete(int? LanguageId)
        {
            var result = await _serviceManager.BookLanguageService.GetBookLanguageById(LanguageId);
            return View(result.entity);
        }

        // POST <BookLanguage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? LanguageId)
        {
            var result = await _serviceManager.BookLanguageService.RemoveBookLanguage(LanguageId);
            return RedirectToAction(nameof(Index));
        }
    }
}
