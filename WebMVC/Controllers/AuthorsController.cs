////////////////////////////////////
// generated AuthorsController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ILogger<AuthorsController> logger;
        private readonly IServiceManager _serviceManager;

        public AuthorsController(IServiceManager serviceManager, ILogger<AuthorsController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Author
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.AuthorService.GetAllAuthor();
            return View(result.entities);
        }

        // GET Author/Details/5
        public async Task<IActionResult> Details(int? AuthorId)
        {
            var result = await _serviceManager.AuthorService.GetAuthorById(AuthorId);
            return View(result.entity);
        }

        // GET Author/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Author/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName,Books")] Author entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.AuthorService.AddAuthor(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Author/Edit/5
        public async Task<IActionResult> Edit(int? AuthorId)
        {
            var result = await _serviceManager.AuthorService.GetAuthorById(AuthorId);
            return View(result.entity);
        }

        // POST Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? AuthorId, [Bind("AuthorId,AuthorName,Books")] Author entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.AuthorService.UpdateAuthor(AuthorId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Author/Delete/5
        public async Task<IActionResult> Delete(int? AuthorId)
        {
            var result = await _serviceManager.AuthorService.GetAuthorById(AuthorId);
            return View(result.entity);
        }

        // POST <Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? AuthorId)
        {
            var result = await _serviceManager.AuthorService.RemoveAuthor(AuthorId);
            return RedirectToAction(nameof(Index));
        }
    }
}
