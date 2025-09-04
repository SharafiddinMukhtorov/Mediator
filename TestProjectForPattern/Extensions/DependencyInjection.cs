using App.Domain.Interfaces;
using App.Inrastructure.Extensions;
using App.Inrastructure.Repositories;
using System.Reflection;
using TestProjectForPattern.Mappings;
using AutoMapper;

namespace TestProjectForPattern.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration); 
        services.RegisterRepositories(configuration);
        //swagger register 
        services.AddSwaggerGen();
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //auto mapper register
        services.AddAutoMapper(cfg => { },
                       typeof(MappingProfile).Assembly);

        return services;
    }
    public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
