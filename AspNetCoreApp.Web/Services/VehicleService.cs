using System.Text.Json;
using AspNetCoreApp.Web.Models;
using System.Text.Json.Serialization;

namespace AspNetCoreApp.Web.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IWebHostEnvironment _environment;
        private List<Brand>? _brands;

        public VehicleService(IWebHostEnvironment environment)
        {
            _environment = environment;
            LoadDataAsync().GetAwaiter().GetResult();
        }

        private async Task LoadDataAsync()
        {
            var jsonPath = Path.Combine(_environment.WebRootPath, "data", "data.json");
            var jsonString = await File.ReadAllTextAsync(jsonPath);
            var data = JsonSerializer.Deserialize<RootObject>(jsonString);
            _brands = data?.Brands?.Brand ?? new List<Brand>();
        }

        public Task<List<Brand>> GetAllBrandsAsync()
        {
            return Task.FromResult(_brands ?? new List<Brand>());
        }

        public Task<Brand?> GetBrandByNameAsync(string brandName)
        {
            return Task.FromResult(_brands?.FirstOrDefault(b => b.Name.Text.Equals(brandName, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<Model?> GetModelByNameAsync(string brandName, string modelName)
        {
            var brand = await GetBrandByNameAsync(brandName);
            return brand?.Models.Model.FirstOrDefault(m => m.Name.Text.Equals(modelName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Generation?> GetGenerationByNameAsync(string brandName, string modelName, string generationName)
        {
            var model = await GetModelByNameAsync(brandName, modelName);
            return model?.Generations.Generation.FirstOrDefault(g => g.Name.Text.Equals(generationName, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class RootObject
    {
        [JsonPropertyName("brands")]
        public Brands Brands { get; set; } = new Brands();
    }

    public class Brands
    {
        [JsonPropertyName("brand")]
        public List<Brand> Brand { get; set; } = new List<Brand>();
    }
}