using AutoMapper;
using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.UseCases;

public class GetAllOfficesUseCase : IGetAllOfficesUseCase
{
    private readonly IOfficesRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllOfficesUseCase> _logger;

    public GetAllOfficesUseCase(IOfficesRepository repository, IMapper mapper, ILogger<GetAllOfficesUseCase> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<OfficesDto>> Execute()
    {
        _logger.LogInformation("Fetching all offices.");
        
        var offices = await _repository.GetAllOfficesAsync();
        _logger.LogInformation("Retrieved {Count} offices from the repository.", offices.Count());
        
        var officesDto = _mapper.Map<IEnumerable<OfficesDto>>(offices);
        _logger.LogInformation("Mapped {Count} offices to DTOs.", officesDto.Count());
        
        return officesDto;
    }
}