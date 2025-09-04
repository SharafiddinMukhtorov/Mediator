using App.Domain.Models;

namespace App.Domain.Interfaces;

public interface IBrandRepository
{
    Task<List<Brand>> GetBrandsAsync();
    Task<Brand> GetBrandByIdAsync(int id);
    Task<Brand> CreateBrandAsync(Brand brand);
    Task<Brand> UpdateBrandAsync(Brand brand);
    Task DeleteBrandAsync(int id);
}
