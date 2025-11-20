using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InstrumentRentalApi.Models
{
    public class Instrument : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Зробив nullable (?), щоб зник Warning

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("categoryId")]
        public string CategoryId { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ownerId")]
        public string? OwnerId { get; set; }
    }
}