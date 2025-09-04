using App.Domain.Interfaces;
using App.Domain.Models;
using App.Inrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace App.Inrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDBContext _context;

    public CategoryRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .Include(c => c.Cars)
            .ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.Cars)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
