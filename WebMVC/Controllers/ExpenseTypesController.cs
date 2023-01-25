////////////////////////////////////
// generated ExpenseTypesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class ExpenseTypesController : Controller
    {
        private readonly ILogger<ExpenseTypesController> logger;
        private readonly IServiceManager _serviceManager;

        public ExpenseTypesController(IServiceManager serviceManager, ILogger<ExpenseTypesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: ExpenseType
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.ExpenseTypeService.GetAllExpenseType();
            return View(result.entities);
        }

        // GET ExpenseType/Details/5
        public async Task<IActionResult> Details(byte? Id)
        {
            var result = await _serviceManager.ExpenseTypeService.GetExpenseTypeById(Id);
            return View(result.entity);
        }

        // GET ExpenseType/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST ExpenseType/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpenseAssignees")] ExpenseType entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseTypeService.AddExpenseType(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ExpenseType/Edit/5
        public async Task<IActionResult> Edit(byte? Id)
        {
            var result = await _serviceManager.ExpenseTypeService.GetExpenseTypeById(Id);
            return View(result.entity);
        }

        // POST ExpenseType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte? Id, [Bind("Id,Name,ExpenseAssignees")] ExpenseType entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseTypeService.UpdateExpenseType(Id,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ExpenseType/Delete/5
        public async Task<IActionResult> Delete(byte? Id)
        {
            var result = await _serviceManager.ExpenseTypeService.GetExpenseTypeById(Id);
            return View(result.entity);
        }

        // POST <ExpenseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte? Id)
        {
            var result = await _serviceManager.ExpenseTypeService.RemoveExpenseType(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
