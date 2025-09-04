using App.Domain.Interfaces;
using App.Domain.Models;
using App.Inrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace App.Inrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly AppDBContext _context;

    public BrandRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetBrandsAsync()
    {
        return await _context.Brands
            .Include(b => b.Cars)
            .ToListAsync();
    }

    public async Task<Brand> GetBrandByIdAsync(int id)
    {
        return await _context.Brands
            .Include(b => b.Cars)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Brand> CreateBrandAsync(Brand brand)
    {
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();
        return brand;
    }

    public async Task<Brand> UpdateBrandAsync(Brand brand)
    {
        _context.Brands.Update(brand);
        await _context.SaveChangesAsync();
        return brand;
    }

    public async Task DeleteBrandAsync(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand != null)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }
}
