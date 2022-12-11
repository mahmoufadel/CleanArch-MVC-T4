////////////////////////////////////
// generated BooksController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> logger;
        private readonly IServiceManager _serviceManager;

        public BooksController(IServiceManager serviceManager, ILogger<BooksController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Book
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.BookService.GetAllBook();
            return View(result.entities);
        }

        // GET Book/Details/5
        public async Task<IActionResult> Details(int? BookId)
        {
            var result = await _serviceManager.BookService.GetBookById(BookId);
            return View(result.entity);
        }

        // GET Book/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Book/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Isbn13,LanguageId,NumPages,PublicationDate,PublisherId,Language,Publisher,OrderLines,Authors")] Book entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.BookService.AddBook(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Book/Edit/5
        public async Task<IActionResult> Edit(int? BookId)
        {
            var result = await _serviceManager.BookService.GetBookById(BookId);
            return View(result.entity);
        }

        // POST Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? BookId, [Bind("BookId,Title,Isbn13,LanguageId,NumPages,PublicationDate,PublisherId,Language,Publisher,OrderLines,Authors")] Book entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.BookService.UpdateBook(BookId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Book/Delete/5
        public async Task<IActionResult> Delete(int? BookId)
        {
            var result = await _serviceManager.BookService.GetBookById(BookId);
            return View(result.entity);
        }

        // POST <Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? BookId)
        {
            var result = await _serviceManager.BookService.RemoveBook(BookId);
            return RedirectToAction(nameof(Index));
        }
    }
}
