namespace OfficeService.Application.DTOs;

public class OfficesDto
{
    public string Id { get; set; }
    public string Address { get; set; }
    public string RegistryPhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public int? PhotoId { get; set; }
}