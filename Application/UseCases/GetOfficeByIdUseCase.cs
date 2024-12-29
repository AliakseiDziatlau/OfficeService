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

    public GetOfficeByIdUseCase(IOfficesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OfficesDto> Execute(string officeId)
    {
        if (string.IsNullOrEmpty(officeId))
        {
            throw new ArgumentException("Office ID cannot be null or empty.", nameof(officeId));
        }
        var office = await _repository.GetOfficeByIdAsync(officeId);
        return _mapper.Map<OfficesDto>(office);
    }
}