////////////////////////////////////
// generated OrderLinesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class OrderLinesController : Controller
    {
        private readonly ILogger<OrderLinesController> logger;
        private readonly IServiceManager _serviceManager;

        public OrderLinesController(IServiceManager serviceManager, ILogger<OrderLinesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: OrderLine
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.OrderLineService.GetAllOrderLine();
            return View(result.entities);
        }

        // GET OrderLine/Details/5
        public async Task<IActionResult> Details(int? LineId)
        {
            var result = await _serviceManager.OrderLineService.GetOrderLineById(LineId);
            return View(result.entity);
        }

        // GET OrderLine/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST OrderLine/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineId,OrderId,BookId,Price,Book,Order")] OrderLine entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.OrderLineService.AddOrderLine(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get OrderLine/Edit/5
        public async Task<IActionResult> Edit(int? LineId)
        {
            var result = await _serviceManager.OrderLineService.GetOrderLineById(LineId);
            return View(result.entity);
        }

        // POST OrderLine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? LineId, [Bind("LineId,OrderId,BookId,Price,Book,Order")] OrderLine entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.OrderLineService.UpdateOrderLine(LineId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get OrderLine/Delete/5
        public async Task<IActionResult> Delete(int? LineId)
        {
            var result = await _serviceManager.OrderLineService.GetOrderLineById(LineId);
            return View(result.entity);
        }

        // POST <OrderLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? LineId)
        {
            var result = await _serviceManager.OrderLineService.RemoveOrderLine(LineId);
            return RedirectToAction(nameof(Index));
        }
    }
}
