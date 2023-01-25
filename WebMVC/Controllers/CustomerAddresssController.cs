////////////////////////////////////
// generated CustomerAddresssController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class CustomerAddresssController : Controller
    {
        private readonly ILogger<CustomerAddresssController> logger;
        private readonly IServiceManager _serviceManager;

        public CustomerAddresssController(IServiceManager serviceManager, ILogger<CustomerAddresssController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }

        // GET: CustomerAddress
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.CustomerAddressService.GetAllCustomerAddress();
            return View(result.entities);
        }

        // GET CustomerAddress/Details/5
        public async Task<IActionResult> Details(int? CustomerId, int? AddressId)
        {
            var result = await _serviceManager.CustomerAddressService.GetCustomerAddressById(CustomerId, AddressId);
            return View(result.entity);
        }

        // GET CustomerAddress/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST CustomerAddress/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,AddressId,StatusId,Address,Customer")] CustomerAddress entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CustomerAddressService.AddCustomerAddress(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get CustomerAddress/Edit/5
        public async Task<IActionResult> Edit(int? CustomerId, int? AddressId)
        {
            var result = await _serviceManager.CustomerAddressService.GetCustomerAddressById(CustomerId, AddressId);
            return View(result.entity);
        }

        // POST CustomerAddress/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? CustomerId, int? AddressId, [Bind("CustomerId,AddressId,StatusId,Address,Customer")] CustomerAddress entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CustomerAddressService.UpdateCustomerAddress(CustomerId, AddressId, entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get CustomerAddress/Delete/5
        public async Task<IActionResult> Delete(int? CustomerId, int? AddressId)
        {
            var result = await _serviceManager.CustomerAddressService.GetCustomerAddressById(CustomerId, AddressId);
            return View(result.entity);
        }

        // POST <CustomerAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? CustomerId, int? AddressId)
        {
            var result = await _serviceManager.CustomerAddressService.RemoveCustomerAddress(CustomerId, AddressId);
            return RedirectToAction(nameof(Index));
        }
    }
}
