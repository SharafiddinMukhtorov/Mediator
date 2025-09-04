using App.Domain.Models;

namespace App.Domain.Interfaces;

public interface ICarRepository
{
    Task<List<Car>> GetAllCarsAsync();
    Task<Car> GetCarByIdAsync(int id);
    Task<Car> CreateCarAsync(Car car);
    Task<Car> UpdateCarAsync(Car car);
    Task DeleteCarAsync(int id);
}
