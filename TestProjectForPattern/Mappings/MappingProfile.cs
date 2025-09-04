using App.Domain.Models;
using AutoMapper;
using TestProjectForPattern.DTOs;

namespace TestProjectForPattern.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<Brand, BrandDto>();
        CreateMap<Category, CategoryDto>();
    }
}
