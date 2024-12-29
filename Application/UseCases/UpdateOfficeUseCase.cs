using AutoMapper;
using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;

namespace OfficeService.Application.UseCases;

public class UpdateOfficeUseCase : IUpdateOfficeUseCase
{
    private readonly IOfficesRepository _repository;
    private readonly IMapper _mapper;

    public UpdateOfficeUseCase(IOfficesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Execute(string officeId, OfficesDto officesDto)
    {
        if (string.IsNullOrEmpty(officeId))
        {
            throw new ArgumentException("Office ID cannot be null or empty.", nameof(officeId));
        }

        if (officesDto == null)
        {
            throw new ArgumentNullException(nameof(officesDto), "Office data transfer object cannot be null.");
        }
        
        var existingOffice = await _repository.GetOfficeByIdAsync(officeId);
        if (existingOffice == null)
        {
            throw new KeyNotFoundException($"Office with id '{officeId}' was not found.");
        }
        
       _mapper.Map(officesDto, existingOffice);
        await _repository.UpdateOfficeAsync(officeId, existingOffice);
    }
}