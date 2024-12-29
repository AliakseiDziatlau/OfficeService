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
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));
        }
        
        var existingOffice = await _repository.GetOfficeByIdAsync(id);
        if (existingOffice == null)
        {
            throw new KeyNotFoundException($"Office with id '{id}' was not found.");
        }
        
        await _repository.DeleteOfficeAsync(id);
    }
}