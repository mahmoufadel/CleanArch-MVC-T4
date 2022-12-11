////////////////////////////////////
// generated CustOrdersController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class CustOrdersController : Controller
    {
        private readonly ILogger<CustOrdersController> logger;
        private readonly IServiceManager _serviceManager;

        public CustOrdersController(IServiceManager serviceManager, ILogger<CustOrdersController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: CustOrder
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.CustOrderService.GetAllCustOrder();
            return View(result.entities);
        }

        // GET CustOrder/Details/5
        public async Task<IActionResult> Details(int? OrderId)
        {
            var result = await _serviceManager.CustOrderService.GetCustOrderById(OrderId);
            return View(result.entity);
        }

        // GET CustOrder/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST CustOrder/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,ShippingMethodId,DestAddressId,Customer,DestAddress,ShippingMethod,OrderHistories,OrderLines")] CustOrder entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CustOrderService.AddCustOrder(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get CustOrder/Edit/5
        public async Task<IActionResult> Edit(int? OrderId)
        {
            var result = await _serviceManager.CustOrderService.GetCustOrderById(OrderId);
            return View(result.entity);
        }

        // POST CustOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? OrderId, [Bind("OrderId,OrderDate,CustomerId,ShippingMethodId,DestAddressId,Customer,DestAddress,ShippingMethod,OrderHistories,OrderLines")] CustOrder entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CustOrderService.UpdateCustOrder(OrderId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get CustOrder/Delete/5
        public async Task<IActionResult> Delete(int? OrderId)
        {
            var result = await _serviceManager.CustOrderService.GetCustOrderById(OrderId);
            return View(result.entity);
        }

        // POST <CustOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? OrderId)
        {
            var result = await _serviceManager.CustOrderService.RemoveCustOrder(OrderId);
            return RedirectToAction(nameof(Index));
        }
    }
}
