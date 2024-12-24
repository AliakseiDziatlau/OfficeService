using OfficeService.Application.Interfaces;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.UseCases;

public class GetAllOfficesUseCase : IGetAllOfficesUseCase
{
    private readonly IOfficesRepository _repository;

    public GetAllOfficesUseCase(IOfficesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Offices>> Execute()
    {
        var offices = await _repository.GetAllOfficesAsync();
        return offices;
    }
}