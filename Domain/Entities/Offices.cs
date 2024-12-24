using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OfficeService.Domain.Entities;

public class Offices
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string Id { get; set; } 
    public string Address { get; set; }
    public int? PhotoId { get; set; } 
    public string RegistryPhoneNumber { get; set; }
    public bool IsActive { get; set; }
}