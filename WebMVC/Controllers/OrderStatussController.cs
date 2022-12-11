////////////////////////////////////
// generated OrderStatussController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class OrderStatussController : Controller
    {
        private readonly ILogger<OrderStatussController> logger;
        private readonly IServiceManager _serviceManager;

        public OrderStatussController(IServiceManager serviceManager, ILogger<OrderStatussController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: OrderStatus
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.OrderStatusService.GetAllOrderStatus();
            return View(result.entities);
        }

        // GET OrderStatus/Details/5
        public async Task<IActionResult> Details(int? StatusId)
        {
            var result = await _serviceManager.OrderStatusService.GetOrderStatusById(StatusId);
            return View(result.entity);
        }

        // GET OrderStatus/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST OrderStatus/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusValue,OrderHistories")] OrderStatus entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.OrderStatusService.AddOrderStatus(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get OrderStatus/Edit/5
        public async Task<IActionResult> Edit(int? StatusId)
        {
            var result = await _serviceManager.OrderStatusService.GetOrderStatusById(StatusId);
            return View(result.entity);
        }

        // POST OrderStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? StatusId, [Bind("StatusId,StatusValue,OrderHistories")] OrderStatus entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.OrderStatusService.UpdateOrderStatus(StatusId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get OrderStatus/Delete/5
        public async Task<IActionResult> Delete(int? StatusId)
        {
            var result = await _serviceManager.OrderStatusService.GetOrderStatusById(StatusId);
            return View(result.entity);
        }

        // POST <OrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? StatusId)
        {
            var result = await _serviceManager.OrderStatusService.RemoveOrderStatus(StatusId);
            return RedirectToAction(nameof(Index));
        }
    }
}
