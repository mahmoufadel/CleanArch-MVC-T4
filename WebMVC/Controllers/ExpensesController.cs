////////////////////////////////////
// generated ExpensesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ILogger<ExpensesController> logger;
        private readonly IServiceManager _serviceManager;

        public ExpensesController(IServiceManager serviceManager, ILogger<ExpensesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Expense
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.ExpenseService.GetAllExpense();
            return View(result.entities);
        }

        // GET Expense/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            var result = await _serviceManager.ExpenseService.GetExpenseById(Id);
            return View(result.entity);
        }

        // GET Expense/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Expense/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,CollectiontypeLkpId,ExpensetypeLkpId,CountryLkpId,Name,CreationDate,EditDate,CreatedBy,EditedBy,CollectiontypeLkp,CountryLkp,ExpenseAssignees,ExpenseSubtypes")] Expense entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseService.AddExpense(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Expense/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            var result = await _serviceManager.ExpenseService.GetExpenseById(Id);
            return View(result.entity);
        }

        // POST Expense/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id, [Bind("Id,StartDate,EndDate,CollectiontypeLkpId,ExpensetypeLkpId,CountryLkpId,Name,CreationDate,EditDate,CreatedBy,EditedBy,CollectiontypeLkp,CountryLkp,ExpenseAssignees,ExpenseSubtypes")] Expense entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseService.UpdateExpense(Id,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Expense/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            var result = await _serviceManager.ExpenseService.GetExpenseById(Id);
            return View(result.entity);
        }

        // POST <Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            var result = await _serviceManager.ExpenseService.RemoveExpense(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
