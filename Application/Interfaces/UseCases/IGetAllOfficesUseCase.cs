using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces.UseCases;

public interface IGetAllOfficesUseCase
{
    Task<IEnumerable<Offices>> Execute();
} 