using OfficeService.Infrastructure.Persistence.Settings;

namespace OfficeService.Application.Configurations;

public static class DatabaseSetup
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
    }
}