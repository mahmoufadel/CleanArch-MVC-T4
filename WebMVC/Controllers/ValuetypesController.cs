////////////////////////////////////
// generated ValuetypesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class ValuetypesController : Controller
    {
        private readonly ILogger<ValuetypesController> logger;
        private readonly IServiceManager _serviceManager;

        public ValuetypesController(IServiceManager serviceManager, ILogger<ValuetypesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Valuetype
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.ValuetypeService.GetAllValuetype();
            return View(result.entities);
        }

        // GET Valuetype/Details/5
        public async Task<IActionResult> Details(byte? Id)
        {
            var result = await _serviceManager.ValuetypeService.GetValuetypeById(Id);
            return View(result.entity);
        }

        // GET Valuetype/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Valuetype/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpenseSubtypes")] Valuetype entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ValuetypeService.AddValuetype(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Valuetype/Edit/5
        public async Task<IActionResult> Edit(byte? Id)
        {
            var result = await _serviceManager.ValuetypeService.GetValuetypeById(Id);
            return View(result.entity);
        }

        // POST Valuetype/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte? Id, [Bind("Id,Name,ExpenseSubtypes")] Valuetype entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ValuetypeService.UpdateValuetype(Id,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Valuetype/Delete/5
        public async Task<IActionResult> Delete(byte? Id)
        {
            var result = await _serviceManager.ValuetypeService.GetValuetypeById(Id);
            return View(result.entity);
        }

        // POST <Valuetype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte? Id)
        {
            var result = await _serviceManager.ValuetypeService.RemoveValuetype(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
