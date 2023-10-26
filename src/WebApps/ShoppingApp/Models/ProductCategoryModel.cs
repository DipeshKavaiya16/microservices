namespace ShoppingApp.Models
{
    public class ProductCategoryModel
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
