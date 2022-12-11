////////////////////////////////////
// generated AddresssController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class AddresssController : Controller
    {
        private readonly ILogger<AddresssController> logger;
        private readonly IServiceManager _serviceManager;

        public AddresssController(IServiceManager serviceManager, ILogger<AddresssController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Address
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.AddressService.GetAllAddress();
            return View(result.entities);
        }

        // GET Address/Details/5
        public async Task<IActionResult> Details(int? AddressId)
        {
            var result = await _serviceManager.AddressService.GetAddressById(AddressId);
            return View(result.entity);
        }

        // GET Address/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Address/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,StreetNumber,StreetName,City,CountryId,Country,CustOrders,CustomerAddresses")] Address entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.AddressService.AddAddress(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Address/Edit/5
        public async Task<IActionResult> Edit(int? AddressId)
        {
            var result = await _serviceManager.AddressService.GetAddressById(AddressId);
            return View(result.entity);
        }

        // POST Address/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? AddressId, [Bind("AddressId,StreetNumber,StreetName,City,CountryId,Country,CustOrders,CustomerAddresses")] Address entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.AddressService.UpdateAddress(AddressId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Address/Delete/5
        public async Task<IActionResult> Delete(int? AddressId)
        {
            var result = await _serviceManager.AddressService.GetAddressById(AddressId);
            return View(result.entity);
        }

        // POST <Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? AddressId)
        {
            var result = await _serviceManager.AddressService.RemoveAddress(AddressId);
            return RedirectToAction(nameof(Index));
        }
    }
}
