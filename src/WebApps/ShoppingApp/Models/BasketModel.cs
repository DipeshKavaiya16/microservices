namespace ShoppingApp.Models
{
    public class BasketModel
    {
        public string UserName { get; set; } = null!;
        public List<BasketItemModel>? Items { get; set; }
        public decimal TotalPrice { get; set; } = 0;
    }
}
