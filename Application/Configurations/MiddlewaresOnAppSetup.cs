using OfficeService.Presentation.Middlewares;
using Serilog;

namespace OfficeService.Application.Configurations;

public static class MiddlewaresOnAppSetup
{
    public static void AddMiddlewares(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseMiddleware<AuthorizationMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}