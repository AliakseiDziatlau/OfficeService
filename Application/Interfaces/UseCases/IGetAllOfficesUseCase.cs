using OfficeService.Application.DTOs;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces.UseCases;

public interface IGetAllOfficesUseCase
{
    Task<IEnumerable<OfficesDto>> Execute();
} 