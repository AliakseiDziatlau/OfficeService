using OfficeService.Domain.Entities;

namespace OfficeService.Application.Interfaces.UseCases;

public interface IGetOfficeByIdUseCase
{
    Task<Offices> Execute(string officeId);
}