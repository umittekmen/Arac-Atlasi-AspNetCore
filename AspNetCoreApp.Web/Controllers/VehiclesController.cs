using Microsoft.AspNetCore.Mvc;
using AspNetCoreApp.Web.Models;
using AspNetCoreApp.Web.Services;

namespace AspNetCoreApp.Web.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _vehicleService.GetAllBrandsAsync();
            return View(brands);
        }

        [HttpGet]
        [Route("Vehicles/Brand/{brandName}")]
        public async Task<IActionResult> Brand(string brandName)
        {
            var brand = await _vehicleService.GetBrandByNameAsync(brandName);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> Model(string brandName, string modelName)
        {
            var model = await _vehicleService.GetModelByNameAsync(brandName, modelName);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.BrandName = brandName;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Generation(string brandName, string modelName, string generationName)
        {
            var generation = await _vehicleService.GetGenerationByNameAsync(brandName, modelName, generationName);
            if (generation == null)
            {
                return NotFound();
            }
            ViewBag.BrandName = brandName;
            ViewBag.ModelName = modelName;
            return View(generation);
        }
    }
} 