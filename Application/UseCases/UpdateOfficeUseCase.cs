using AutoMapper;
using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;

namespace OfficeService.Application.UseCases;

public class UpdateOfficeUseCase : IUpdateOfficeUseCase
{
    private readonly IOfficesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateOfficeUseCase> _logger;

    public UpdateOfficeUseCase(IOfficesRepository repository, IMapper mapper, ILogger<UpdateOfficeUseCase> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Execute(string officeId, OfficesDto officesDto)
    {
        if (string.IsNullOrEmpty(officeId))
        {
            _logger.LogError("Attempted to update an office with a null or empty ID.");
            throw new ArgumentException("Office ID cannot be null or empty.", nameof(officeId));
        }

        if (officesDto == null)
        {
            _logger.LogError("Attempted to update an office with a null DTO.");
            throw new ArgumentNullException(nameof(officesDto), "Office data transfer object cannot be null.");
        }
        
        _logger.LogInformation("Fetching office with ID: {OfficeId}", officeId);
        var existingOffice = await _repository.GetOfficeByIdAsync(officeId);
        if (existingOffice == null)
        {
            _logger.LogWarning("Office with ID: {OfficeId} was not found.", officeId);
            throw new KeyNotFoundException($"Office with id '{officeId}' was not found.");
        }
        _logger.LogInformation("Mapping updated data to the existing office entity.");
        _mapper.Map(officesDto, existingOffice);
       
        _logger.LogInformation("Updating office with ID: {OfficeId}.", officeId);
        await _repository.UpdateOfficeAsync(officeId, existingOffice);
        _logger.LogInformation("Successfully updated office with ID: {OfficeId}.", officeId);
    }
}