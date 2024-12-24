using OfficeService.Application.DTOs;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces;

public interface IOfficesService
{
    Task<Offices> GetOfficeByIdAsync(int officeId);
    Task<IEnumerable<Offices>> GetAllOfficesAsync();
    Task CreateOfficeAsync(OfficesDto officesDto);
    Task UpdateOfficeAsync(OfficesDto officesDto);
    Task DeleteOfficeAsync(int officeId);
}