using OfficeService.Application.DTOs;

namespace OfficeService.Application.Interfaces.UseCases;

public interface IUpdateOfficeUseCase
{
    Task Execute(string officeId, OfficesDto officeDto);
}