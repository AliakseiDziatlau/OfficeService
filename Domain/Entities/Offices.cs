using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OfficeService.Domain.Entities;

public class Offices
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; } 
    [BsonElement("address")]
    public string Address { get; set; }
    [BsonElement("photoId")]
    public int? PhotoId { get; set; } 
    [BsonElement("registryPhoneNumber")]
    public string RegistryPhoneNumber { get; set; }
    [BsonElement("isActive")]
    public bool IsActive { get; set; }
}