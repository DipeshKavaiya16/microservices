namespace Shopping.Aggregator.Models
{
    public class CatalogModel
    {
        public string? Id { get; set; }
        public string CategoryId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int AvailbleQuantity { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
