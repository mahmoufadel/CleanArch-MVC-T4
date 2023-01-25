////////////////////////////////////
// generated AddressStatussController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class AddressStatussController : Controller
    {
        private readonly ILogger<AddressStatussController> logger;
        private readonly IServiceManager _serviceManager;

        public AddressStatussController(IServiceManager serviceManager, ILogger<AddressStatussController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }

        // GET: AddressStatus
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.AddressStatusService.GetAllAddressStatus();
            return View(result.entities);
        }

        // GET AddressStatus/Details/5
        public async Task<IActionResult> Details(int? StatusId)
        {
            var result = await _serviceManager.AddressStatusService.GetAddressStatusById(StatusId);
            return View(result.entity);
        }

        // GET AddressStatus/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST AddressStatus/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,AddressStatus1")] AddressStatus entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.AddressStatusService.AddAddressStatus(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get AddressStatus/Edit/5
        public async Task<IActionResult> Edit(int? StatusId)
        {
            var result = await _serviceManager.AddressStatusService.GetAddressStatusById(StatusId);
            return View(result.entity);
        }

        // POST AddressStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? StatusId, [Bind("StatusId,AddressStatus1")] AddressStatus entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.AddressStatusService.UpdateAddressStatus(StatusId, entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get AddressStatus/Delete/5
        public async Task<IActionResult> Delete(int? StatusId)
        {
            var result = await _serviceManager.AddressStatusService.GetAddressStatusById(StatusId);
            return View(result.entity);
        }

        // POST <AddressStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? StatusId)
        {
            var result = await _serviceManager.AddressStatusService.RemoveAddressStatus(StatusId);
            return RedirectToAction(nameof(Index));
        }
    }
}
