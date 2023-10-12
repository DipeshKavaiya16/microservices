using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class ProductCategory
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
