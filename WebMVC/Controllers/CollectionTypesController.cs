////////////////////////////////////
// generated CollectionTypesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class CollectionTypesController : Controller
    {
        private readonly ILogger<CollectionTypesController> logger;
        private readonly IServiceManager _serviceManager;

        public CollectionTypesController(IServiceManager serviceManager, ILogger<CollectionTypesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: CollectionType
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.CollectionTypeService.GetAllCollectionType();
            return View(result.entities);
        }

        // GET CollectionType/Details/5
        public async Task<IActionResult> Details(byte? Id)
        {
            var result = await _serviceManager.CollectionTypeService.GetCollectionTypeById(Id);
            return View(result.entity);
        }

        // GET CollectionType/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST CollectionType/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Expenses")] CollectionType entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CollectionTypeService.AddCollectionType(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get CollectionType/Edit/5
        public async Task<IActionResult> Edit(byte? Id)
        {
            var result = await _serviceManager.CollectionTypeService.GetCollectionTypeById(Id);
            return View(result.entity);
        }

        // POST CollectionType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte? Id, [Bind("Id,Name,Expenses")] CollectionType entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CollectionTypeService.UpdateCollectionType(Id,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get CollectionType/Delete/5
        public async Task<IActionResult> Delete(byte? Id)
        {
            var result = await _serviceManager.CollectionTypeService.GetCollectionTypeById(Id);
            return View(result.entity);
        }

        // POST <CollectionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte? Id)
        {
            var result = await _serviceManager.CollectionTypeService.RemoveCollectionType(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
