using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;

namespace OfficeService.Application.UseCases;

public class DeleteOfficeUseCase : IDeleteOfficeUseCase
{
    private readonly IOfficesRepository _repository;
    private readonly ILogger<DeleteOfficeUseCase> _logger;

    public DeleteOfficeUseCase(IOfficesRepository repository, ILogger<DeleteOfficeUseCase> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task Execute(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            _logger.LogError("Attempted to delete an office with a null or empty ID.");
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));
        }
        
        _logger.LogInformation("Attempting to delete office with ID: {Id}", id);
        var existingOffice = await _repository.GetOfficeByIdAsync(id);
        if (existingOffice == null)
        {
            _logger.LogWarning("Office with ID {Id} was not found.", id);
            throw new KeyNotFoundException($"Office with id '{id}' was not found.");
        }
        
        await _repository.DeleteOfficeAsync(id);
        _logger.LogInformation("Successfully deleted office with ID: {Id}", id);
    }
}