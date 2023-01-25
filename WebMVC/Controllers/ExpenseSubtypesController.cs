////////////////////////////////////
// generated ExpenseSubtypesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class ExpenseSubtypesController : Controller
    {
        private readonly ILogger<ExpenseSubtypesController> logger;
        private readonly IServiceManager _serviceManager;

        public ExpenseSubtypesController(IServiceManager serviceManager, ILogger<ExpenseSubtypesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: ExpenseSubtype
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.ExpenseSubtypeService.GetAllExpenseSubtype();
            return View(result.entities);
        }

        // GET ExpenseSubtype/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            var result = await _serviceManager.ExpenseSubtypeService.GetExpenseSubtypeById(Id);
            return View(result.entity);
        }

        // GET ExpenseSubtype/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST ExpenseSubtype/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,ValuetypeLkpId,MaximumValue,MinimumValue,GlAccount,ExpenseId,Name,CreationDate,EditDate,CreatedBy,EditedBy,Expense,ValuetypeLkp")] ExpenseSubtype entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseSubtypeService.AddExpenseSubtype(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ExpenseSubtype/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            var result = await _serviceManager.ExpenseSubtypeService.GetExpenseSubtypeById(Id);
            return View(result.entity);
        }

        // POST ExpenseSubtype/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id, [Bind("Id,Value,ValuetypeLkpId,MaximumValue,MinimumValue,GlAccount,ExpenseId,Name,CreationDate,EditDate,CreatedBy,EditedBy,Expense,ValuetypeLkp")] ExpenseSubtype entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseSubtypeService.UpdateExpenseSubtype(Id,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ExpenseSubtype/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            var result = await _serviceManager.ExpenseSubtypeService.GetExpenseSubtypeById(Id);
            return View(result.entity);
        }

        // POST <ExpenseSubtype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            var result = await _serviceManager.ExpenseSubtypeService.RemoveExpenseSubtype(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
