using AspNetCoreApp.Web.Models;

namespace AspNetCoreApp.Web.Services
{
    public interface IVehicleService
    {
        Task<List<Brand>> GetAllBrandsAsync();
        Task<Brand?> GetBrandByNameAsync(string brandName);
        Task<Model?> GetModelByNameAsync(string brandName, string modelName);
        Task<Generation?> GetGenerationByNameAsync(string brandName, string modelName, string generationName);
    }
} 