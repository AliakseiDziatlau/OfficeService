using OfficeService.Application.DTOs;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces.UseCases;

public interface IGetOfficeByIdUseCase
{
    Task<OfficesDto> Execute(string officeId);
}