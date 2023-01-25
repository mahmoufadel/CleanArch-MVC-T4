////////////////////////////////////
// generated ShippingMethodsController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class ShippingMethodsController : Controller
    {
        private readonly ILogger<ShippingMethodsController> logger;
        private readonly IServiceManager _serviceManager;

        public ShippingMethodsController(IServiceManager serviceManager, ILogger<ShippingMethodsController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }

        // GET: ShippingMethod
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.ShippingMethodService.GetAllShippingMethod();
            return View(result.entities);
        }

        // GET ShippingMethod/Details/5
        public async Task<IActionResult> Details(int? MethodId)
        {
            var result = await _serviceManager.ShippingMethodService.GetShippingMethodById(MethodId);
            return View(result.entity);
        }

        // GET ShippingMethod/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST ShippingMethod/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MethodId,MethodName,Cost,CustOrders")] ShippingMethod entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ShippingMethodService.AddShippingMethod(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ShippingMethod/Edit/5
        public async Task<IActionResult> Edit(int? MethodId)
        {
            var result = await _serviceManager.ShippingMethodService.GetShippingMethodById(MethodId);
            return View(result.entity);
        }

        // POST ShippingMethod/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? MethodId, [Bind("MethodId,MethodName,Cost,CustOrders")] ShippingMethod entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.ShippingMethodService.UpdateShippingMethod(MethodId, entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get ShippingMethod/Delete/5
        public async Task<IActionResult> Delete(int? MethodId)
        {
            var result = await _serviceManager.ShippingMethodService.GetShippingMethodById(MethodId);
            return View(result.entity);
        }

        // POST <ShippingMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? MethodId)
        {
            var result = await _serviceManager.ShippingMethodService.RemoveShippingMethod(MethodId);
            return RedirectToAction(nameof(Index));
        }
    }
}
