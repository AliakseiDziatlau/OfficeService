using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces;
using OfficeService.Application.Interfaces.UseCases;
using OfficeService.Domain.Entities;

namespace OfficeService.Application.Services;

public class OfficesService : IOfficesService
{
    private readonly ICreateOfficeUseCase _createOfficeUseCase;
    private readonly IDeleteOfficeUseCase _deleteOfficeUseCase;
    private readonly IGetOfficeByIdUseCase _getOfficeByIdUseCase;
    private readonly IUpdateOfficeUseCase _updateOfficeUseCase;
    private readonly IGetAllOfficesUseCase _getAllOfficesUseCase;

    public OfficesService(
        ICreateOfficeUseCase createOfficeUseCase, 
        IDeleteOfficeUseCase deleteOfficeUseCase,
        IGetOfficeByIdUseCase getOfficeByIdUseCase,
        IUpdateOfficeUseCase updateOfficeUseCase,
        IGetAllOfficesUseCase getAllOfficesUseCase
    )
    {
        _createOfficeUseCase = createOfficeUseCase;
        _deleteOfficeUseCase = deleteOfficeUseCase;
        _getOfficeByIdUseCase = getOfficeByIdUseCase;
        _updateOfficeUseCase = updateOfficeUseCase;
        _getAllOfficesUseCase = getAllOfficesUseCase;
    }

    public async Task<Offices> GetOfficeByIdAsync(string officeId)
    {
       return await _getOfficeByIdUseCase.Execute(officeId);
    }

    public async Task<IEnumerable<Offices>> GetAllOfficesAsync()
    {
        return await _getAllOfficesUseCase.Execute();
    }

    public async Task CreateOfficeAsync(OfficesDto officesDto)
    {
        await _createOfficeUseCase.Execute(officesDto);
    }

    public async Task UpdateOfficeAsync(OfficesDto officesDto)
    {
        await _updateOfficeUseCase.Execute(officesDto);
    }

    public async Task DeleteOfficeAsync(string officeId)
    {
        await _deleteOfficeUseCase.Execute(officeId);
    }
}