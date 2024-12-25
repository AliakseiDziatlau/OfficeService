using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces.Repositories;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.UseCases;

public class CreateOfficeUseCase : ICreateOfficeUseCase
{
    private readonly IOfficesRepository _repository;

    public CreateOfficeUseCase(IOfficesRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(OfficesDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "Office data transfer object cannot be null.");
        }
        
        var office = new Offices
        {
            Address = dto.Address,
            RegistryPhoneNumber = dto.RegistryPhoneNumber,
            IsActive = dto.IsActive,
            PhotoId = dto.PhotoId
        };
        
        await _repository.CreateOfficeAsync(office);
    }
}