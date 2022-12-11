////////////////////////////////////
// generated SamplesController.cs //
////////////////////////////////////
using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVC.Controllers
{
    public class SamplesController : Controller
    {
        private readonly ILogger<SamplesController> logger;
        private readonly IServiceManager _serviceManager;

        public SamplesController(IServiceManager serviceManager, ILogger<SamplesController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }
        
        // GET: Sample
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.SampleService.GetAllSample();
            return View(result.entities);
        }

        // GET Sample/Details/5
        public async Task<IActionResult> Details(int? Id1,int? Id2,int? Id3)
        {
            var result = await _serviceManager.SampleService.GetSampleById(Id1,Id2,Id3);
            return View(result.entity);
        }

        // GET Sample/Create>
        public IActionResult Create()
        {
            return View();
        }

        // POST Sample/Create>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id1,Id2,Id3,Name,Description")] Sample entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.SampleService.AddSample(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Sample/Edit/5
        public async Task<IActionResult> Edit(int? Id1,int? Id2,int? Id3)
        {
            var result = await _serviceManager.SampleService.GetSampleById(Id1,Id2,Id3);
            return View(result.entity);
        }

        // POST Sample/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id1,int? Id2,int? Id3, [Bind("Id1,Id2,Id3,Name,Description")] Sample entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceManager.SampleService.UpdateSample(Id1,Id2,Id3,entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // Get Sample/Delete/5
        public async Task<IActionResult> Delete(int? Id1,int? Id2,int? Id3)
        {
            var result = await _serviceManager.SampleService.GetSampleById(Id1,Id2,Id3);
            return View(result.entity);
        }

        // POST <Sample/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id1,int? Id2,int? Id3)
        {
            var result = await _serviceManager.SampleService.RemoveSample(Id1,Id2,Id3);
            return RedirectToAction(nameof(Index));
        }
    }
}
