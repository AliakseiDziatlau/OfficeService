using MongoDB.Driver;
using OfficeService.Application.Interfaces;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Domain.Entities;
using OfficeService.Infrastructure.Persistence.Contexts;

namespace OfficeService.Infrastructure.Persistence.Repositories;

public class OfficesRepository : IOfficesRepository
{
    private readonly IMongoCollection<Offices> _offices;

    public OfficesRepository(MongoDbContext context)
    {
        _offices = context.Offices;
    }

    public async Task<Offices> GetOfficeByIdAsync(string officeId)
    {
        return await _offices.Find(o => o.Id == officeId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Offices>> GetAllOfficesAsync()
    {
        return await _offices.Find(o => true).ToListAsync();
    }

    public async Task CreateOfficeAsync(Offices office)
    {
        await _offices.InsertOneAsync(office);
    }

    public async Task UpdateOfficeAsync(string officeId, Offices office)
    {
        await _offices.ReplaceOneAsync(o => o.Id == officeId, office);
    }

    public async Task DeleteOfficeAsync(string officeId)
    {
        await _offices.DeleteOneAsync(o => o.Id == officeId);
    }
}