using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;

namespace OfficeService.Application.UseCases;

public class UpdateOfficeUseCase : IUpdateOfficeUseCase
{
    private readonly IOfficesRepository _repository;

    public UpdateOfficeUseCase(IOfficesRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(OfficesDto officesDto)
    {
        
    }
}