////////////////////////////////////
// generated ExpenseAssigneesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class ExpenseAssigneesController : Controller
    {
        private readonly ILogger<ExpenseAssigneesController> logger;
        private readonly IServiceManager _serviceManager;

        public ExpenseAssigneesController(IServiceManager serviceManager, ILogger<ExpenseAssigneesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: ExpenseAssignee
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.ExpenseAssigneeService.GetAllExpenseAssignee();
            return View(result.entities);
        }

        // GET ExpenseAssignee/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            var result = await _serviceManager.ExpenseAssigneeService.GetExpenseAssigneeById(Id);
            return View(result.entity);
        }

        // GET ExpenseAssignee/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST ExpenseAssignee/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExpenseId,ExpensetypeLkpId,CreationDate,EditDate,CreatedBy,EditedBy,Expense,ExpensetypeLkp")] ExpenseAssignee entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseAssigneeService.AddExpenseAssignee(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ExpenseAssignee/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            var result = await _serviceManager.ExpenseAssigneeService.GetExpenseAssigneeById(Id);
            return View(result.entity);
        }

        // POST ExpenseAssignee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id, [Bind("Id,ExpenseId,ExpensetypeLkpId,CreationDate,EditDate,CreatedBy,EditedBy,Expense,ExpensetypeLkp")] ExpenseAssignee entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ExpenseAssigneeService.UpdateExpenseAssignee(Id,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ExpenseAssignee/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            var result = await _serviceManager.ExpenseAssigneeService.GetExpenseAssigneeById(Id);
            return View(result.entity);
        }

        // POST <ExpenseAssignee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            var result = await _serviceManager.ExpenseAssigneeService.RemoveExpenseAssignee(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
