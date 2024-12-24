using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;

namespace OfficeService.Application.UseCases;

public class CreateOfficeUseCase : ICreateOfficeUseCase
{
    private readonly IOfficesRepository _repository;

    public CreateOfficeUseCase(IOfficesRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(OfficesDto dto)
    {
        
    }
}