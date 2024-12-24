using OfficeService.Application.DTOs;

namespace OfficeService.Application.Interfaces.UseCases;

public interface ICreateOfficeUseCase
{
    Task Execute(OfficesDto officeDto);
}