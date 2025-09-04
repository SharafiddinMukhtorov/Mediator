using App.Domain.Interfaces;
using App.Domain.Models;
using App.Inrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace App.Inrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDBContext _context;
        public CarRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            var existingCar = await _context.Cars.FindAsync(car.Id);
            if (existingCar == null) return null;

            existingCar.Name = car.Name;
            existingCar.Price = car.Price;
            existingCar.BrandId = car.BrandId;
            existingCar.CategoryId = car.CategoryId;

            await _context.SaveChangesAsync();
            return existingCar;
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
