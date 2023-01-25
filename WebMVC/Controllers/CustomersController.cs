////////////////////////////////////
// generated CustomersController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> logger;
        private readonly IServiceManager _serviceManager;

        public CustomersController(IServiceManager serviceManager, ILogger<CustomersController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }

        // GET: Customer
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.CustomerService.GetAllCustomer();
            return View(result.entities);
        }

        // GET Customer/Details/5
        public async Task<IActionResult> Details(int? CustomerId)
        {
            var result = await _serviceManager.CustomerService.GetCustomerById(CustomerId);
            return View(result.entity);
        }

        // GET Customer/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Customer/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Email,CustOrders,CustomerAddresses")] Customer entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CustomerService.AddCustomer(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Customer/Edit/5
        public async Task<IActionResult> Edit(int? CustomerId)
        {
            var result = await _serviceManager.CustomerService.GetCustomerById(CustomerId);
            return View(result.entity);
        }

        // POST Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? CustomerId, [Bind("CustomerId,FirstName,LastName,Email,CustOrders,CustomerAddresses")] Customer entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CustomerService.UpdateCustomer(CustomerId, entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Customer/Delete/5
        public async Task<IActionResult> Delete(int? CustomerId)
        {
            var result = await _serviceManager.CustomerService.GetCustomerById(CustomerId);
            return View(result.entity);
        }

        // POST <Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? CustomerId)
        {
            var result = await _serviceManager.CustomerService.RemoveCustomer(CustomerId);
            return RedirectToAction(nameof(Index));
        }
    }
}
