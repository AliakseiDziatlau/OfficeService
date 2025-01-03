using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces.Repositories;

public interface IOfficesRepository
{
    Task<Offices> GetOfficeByIdAsync(string officeId);
    Task<IEnumerable<Offices>> GetAllOfficesAsync();
    Task CreateOfficeAsync(Offices office);
    Task UpdateOfficeAsync(string officeId, Offices office);
    Task DeleteOfficeAsync(string officeId);
}