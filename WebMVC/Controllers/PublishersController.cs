////////////////////////////////////
// generated PublishersController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class PublishersController : Controller
    {
        private readonly ILogger<PublishersController> logger;
        private readonly IServiceManager _serviceManager;

        public PublishersController(IServiceManager serviceManager, ILogger<PublishersController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Publisher
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.PublisherService.GetAllPublisher();
            return View(result.entities);
        }

        // GET Publisher/Details/5
        public async Task<IActionResult> Details(int? PublisherId)
        {
            var result = await _serviceManager.PublisherService.GetPublisherById(PublisherId);
            return View(result.entity);
        }

        // GET Publisher/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Publisher/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,Books")] Publisher entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.PublisherService.AddPublisher(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Publisher/Edit/5
        public async Task<IActionResult> Edit(int? PublisherId)
        {
            var result = await _serviceManager.PublisherService.GetPublisherById(PublisherId);
            return View(result.entity);
        }

        // POST Publisher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? PublisherId, [Bind("PublisherId,PublisherName,Books")] Publisher entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.PublisherService.UpdatePublisher(PublisherId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Publisher/Delete/5
        public async Task<IActionResult> Delete(int? PublisherId)
        {
            var result = await _serviceManager.PublisherService.GetPublisherById(PublisherId);
            return View(result.entity);
        }

        // POST <Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? PublisherId)
        {
            var result = await _serviceManager.PublisherService.RemovePublisher(PublisherId);
            return RedirectToAction(nameof(Index));
        }
    }
}
