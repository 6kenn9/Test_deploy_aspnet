using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using InstrumentRentalApi.Models; 

namespace InstrumentRentalApi.Models
{
    public class Category : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [Required(ErrorMessage = "Назва категорії є обов'язковою.")]
        public string Name { get; set; } = string.Empty;
    }
}