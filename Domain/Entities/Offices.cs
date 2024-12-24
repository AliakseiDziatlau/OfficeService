using System.ComponentModel.DataAnnotations;

namespace OfficeService.Domain.Entities;

public class Offices
{
    [Key]
    public int Id { get; set; }
    public string Address { get; set; }
    public int photoId { get; set; }
    public string registryPhoneNumber { get; set; }
    public bool isActive { get; set; }
}