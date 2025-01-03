using AutoMapper;
using OfficeService.Application.DTOs;
using OfficeService.Domain.Entities;

namespace OfficeService.Infrastructure.Mappings;

public class OfficeMappingProfile : Profile
{
    public OfficeMappingProfile()
    {
        CreateMap<Offices, OfficesDto>().ReverseMap();
    }
}