using AutoMapper;
using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.UseCases;

public class GetOfficeByIdUseCase : IGetOfficeByIdUseCase
{
    private readonly IOfficesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetOfficeByIdUseCase> _logger;

    public GetOfficeByIdUseCase(IOfficesRepository repository, IMapper mapper, ILogger<GetOfficeByIdUseCase> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<OfficesDto> Execute(string officeId)
    {
        if (string.IsNullOrEmpty(officeId))
        {
            _logger.LogError("Attempted to fetch office with a null or empty ID.");
            throw new ArgumentException("Office ID cannot be null or empty.", nameof(officeId));
        }
        
        _logger.LogInformation("Fetching office with ID: {OfficeId}", officeId);
        var office = await _repository.GetOfficeByIdAsync(officeId);
        
        _logger.LogInformation("Successfully retrieved office with ID: {OfficeId}. Mapping to DTO.", officeId);
        return _mapper.Map<OfficesDto>(office);
    }
}