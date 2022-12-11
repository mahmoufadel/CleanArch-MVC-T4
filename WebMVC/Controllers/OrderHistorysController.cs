////////////////////////////////////
// generated OrderHistorysController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class OrderHistorysController : Controller
    {
        private readonly ILogger<OrderHistorysController> logger;
        private readonly IServiceManager _serviceManager;

        public OrderHistorysController(IServiceManager serviceManager, ILogger<OrderHistorysController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: OrderHistory
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.OrderHistoryService.GetAllOrderHistory();
            return View(result.entities);
        }

        // GET OrderHistory/Details/5
        public async Task<IActionResult> Details(int? HistoryId)
        {
            var result = await _serviceManager.OrderHistoryService.GetOrderHistoryById(HistoryId);
            return View(result.entity);
        }

        // GET OrderHistory/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST OrderHistory/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,OrderId,StatusId,StatusDate,Order,Status")] OrderHistory entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.OrderHistoryService.AddOrderHistory(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get OrderHistory/Edit/5
        public async Task<IActionResult> Edit(int? HistoryId)
        {
            var result = await _serviceManager.OrderHistoryService.GetOrderHistoryById(HistoryId);
            return View(result.entity);
        }

        // POST OrderHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? HistoryId, [Bind("HistoryId,OrderId,StatusId,StatusDate,Order,Status")] OrderHistory entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.OrderHistoryService.UpdateOrderHistory(HistoryId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get OrderHistory/Delete/5
        public async Task<IActionResult> Delete(int? HistoryId)
        {
            var result = await _serviceManager.OrderHistoryService.GetOrderHistoryById(HistoryId);
            return View(result.entity);
        }

        // POST <OrderHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? HistoryId)
        {
            var result = await _serviceManager.OrderHistoryService.RemoveOrderHistory(HistoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
