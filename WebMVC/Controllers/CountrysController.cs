////////////////////////////////////
// generated CountrysController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class CountrysController : Controller
    {
        private readonly ILogger<CountrysController> logger;
        private readonly IServiceManager _serviceManager;

        public CountrysController(IServiceManager serviceManager, ILogger<CountrysController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Country
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.CountryService.GetAllCountry();
            return View(result.entities);
        }

        // GET Country/Details/5
        public async Task<IActionResult> Details(int? CountryId)
        {
            var result = await _serviceManager.CountryService.GetCountryById(CountryId);
            return View(result.entity);
        }

        // GET Country/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Country/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,CountryName,Addresses")] Country entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CountryService.AddCountry(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Country/Edit/5
        public async Task<IActionResult> Edit(int? CountryId)
        {
            var result = await _serviceManager.CountryService.GetCountryById(CountryId);
            return View(result.entity);
        }

        // POST Country/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? CountryId, [Bind("CountryId,CountryName,Addresses")] Country entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.CountryService.UpdateCountry(CountryId,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Country/Delete/5
        public async Task<IActionResult> Delete(int? CountryId)
        {
            var result = await _serviceManager.CountryService.GetCountryById(CountryId);
            return View(result.entity);
        }

        // POST <Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? CountryId)
        {
            var result = await _serviceManager.CountryService.RemoveCountry(CountryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
