using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OfficeService.Domain.Entities;
using OfficeService.Infrastructure.Persistence.Settings;

namespace OfficeService.Infrastructure.Persistence.Contexts;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
        _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
    }
    
    public IMongoCollection<Offices> Offices => _database.GetCollection<Offices>("Offices");
}