using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string CategoryId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int AvailbleQuantity { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
