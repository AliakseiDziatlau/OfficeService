using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces.Repositories;

public interface IOfficesRepository
{
    Task<Offices> GetOfficeByIdAsync(int officeId);
    Task<IEnumerable<Offices>> GetOfficesAsync();
    Task CreateOfficeAsync(Offices office);
    Task UpdateOfficeAsync(Offices office);
    Task DeleteOfficeAsync(int officeId);
}