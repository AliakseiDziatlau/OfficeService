using OfficeService.Application.Interfaces;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Application.Services;
using OfficeService.Application.UseCases;
using OfficeService.Infrastructure.Persistence.Repositories;
using OfficeService.Infrastructure.Persistence.Settings;

var builder = WebApplication.CreateBuilder(args);

var enviroment = builder.Environment.EnvironmentName;
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{enviroment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));
    
//DI container
builder.Services.AddScoped<IOfficesService, OfficesService>();
builder.Services.AddScoped<ICreateOfficeUseCase, CreateOfficeUseCase>();
builder.Services.AddScoped<IDeleteOfficeUseCase, DeleteOfficeUseCase>();
builder.Services.AddScoped<IUpdateOfficeUseCase, UpdateOfficeUseCase>();
builder.Services.AddScoped<IGetAllOfficesUseCase, GetAllOfficesUseCase>();
builder.Services.AddScoped<IGetOfficeByIdUseCase, GetOfficeByIdUseCase>();
builder.Services.AddScoped<IOfficesRepository, OfficesRepository>();
builder.Services.AddSingleton<MongoDbSettings>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); 
    });
}    

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();