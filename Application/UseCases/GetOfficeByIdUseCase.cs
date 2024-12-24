using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.UseCases;

public class GetOfficeByIdUseCase : IGetOfficeByIdUseCase
{
    private readonly IOfficesRepository _repository;

    public GetOfficeByIdUseCase(IOfficesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Offices> Execute(int officeId)
    {
        return new Offices();
    }
}