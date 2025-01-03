using AutoMapper;
using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.UseCases;

public class CreateOfficeUseCase : ICreateOfficeUseCase
{
    private readonly IOfficesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateOfficeUseCase> _logger;

    public CreateOfficeUseCase(IOfficesRepository repository, IMapper mapper, ILogger<CreateOfficeUseCase> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Execute(OfficesDto dto)
    {
        if (dto == null)
        {
            _logger.LogError("Attempted to create an office with a null DTO.");
            throw new ArgumentNullException(nameof(dto), "Office data transfer object cannot be null.");
        }
        _logger.LogInformation("Mapping OfficesDto to domain entity.");
        var office = _mapper.Map<Offices>(dto);
        _logger.LogInformation("Attempting to create office with Address: {Address}", dto.Address);
        await _repository.CreateOfficeAsync(office);
        _logger.LogInformation("Successfully created office with Address: {Address}", dto.Address);
    }
}