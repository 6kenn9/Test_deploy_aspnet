using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InstrumentRentalApi.Models
{
    public class User : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("passwordHash")]
        public string? PasswordHash { get; set; }
    }
}