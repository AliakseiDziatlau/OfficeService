namespace OfficeService.Presentation.Middlewares;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public AuthorizationMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _next = next;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized: Missing or invalid token.");
            return;
        }

        var token = authorizationHeader["Bearer ".Length..].Trim();
        
        var authServerUrl = _configuration["PathToAuthentificationService"];
        var client = _httpClientFactory.CreateClient();

        var response = await client.PostAsJsonAsync($"{authServerUrl}/api/auth/authorize", new { AccessToken = token });

        if (!response.IsSuccessStatusCode)
        {
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsync(await response.Content.ReadAsStringAsync());
            return;
        }
        
        await _next(context);
    }
}