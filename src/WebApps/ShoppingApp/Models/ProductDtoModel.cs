namespace ShoppingApp.Models
{
    public class ProductDtoModel
    {
        public string? Id { get; set; }
        public string CategoryId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int AvailbleQuantity { get; set; }
        public string ImageFile { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
