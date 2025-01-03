using OfficeService.Application.DTOs;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces;

public interface IOfficesService
{
    Task<OfficesDto> GetOfficeByIdAsync(string officeId);
    Task<IEnumerable<OfficesDto>> GetAllOfficesAsync();
    Task CreateOfficeAsync(OfficesDto officesDto);
    Task UpdateOfficeAsync(string officeId, OfficesDto officesDto);
    Task DeleteOfficeAsync(string officeId);
}