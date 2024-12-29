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

    public GetAllOfficesUseCase(IOfficesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OfficesDto>> Execute()
    {
        var offices = await _repository.GetAllOfficesAsync();
        return _mapper.Map<IEnumerable<OfficesDto>>(offices);
    }
}