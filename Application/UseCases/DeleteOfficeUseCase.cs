using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;

namespace OfficeService.Application.UseCases;

public class DeleteOfficeUseCase : IDeleteOfficeUseCase
{
    private readonly IOfficesRepository _repository;

    public DeleteOfficeUseCase(IOfficesRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(string id)
    {
        
    }
}