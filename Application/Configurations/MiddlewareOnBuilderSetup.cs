namespace OfficeService.Application.Configurations;

public static class MiddlewareOnBuilderSetup
{
    public static void AddMiddlearesAndSwagger(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddHttpClient();
    }
}