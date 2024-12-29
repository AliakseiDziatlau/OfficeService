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

    public CreateOfficeUseCase(IOfficesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Execute(OfficesDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "Office data transfer object cannot be null.");
        }

        var office = _mapper.Map<Offices>(dto);
        await _repository.CreateOfficeAsync(office);
    }
}