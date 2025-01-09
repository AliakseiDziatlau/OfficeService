using OfficeService.Application.Interfaces;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Application.Services;
using OfficeService.Application.UseCases;
using OfficeService.Infrastructure.Persistence.Contexts;
using OfficeService.Infrastructure.Persistence.Repositories;

namespace OfficeService.Application.Configurations;

public static class DependencyInjectionSetup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));
        services.AddScoped<IOfficesService, OfficesService>();
        services.AddScoped<ICreateOfficeUseCase, CreateOfficeUseCase>();
        services.AddScoped<IDeleteOfficeUseCase, DeleteOfficeUseCase>();
        services.AddScoped<IUpdateOfficeUseCase, UpdateOfficeUseCase>();
        services.AddScoped<IGetAllOfficesUseCase, GetAllOfficesUseCase>();
        services.AddScoped<IGetOfficeByIdUseCase, GetOfficeByIdUseCase>();
        services.AddScoped<IOfficesRepository, OfficesRepository>();
        services.AddSingleton<MongoDbContext>();
    }
}