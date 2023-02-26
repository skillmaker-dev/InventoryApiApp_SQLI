namespace Domain.Entities
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public int Barcode { get; set; }
    }
}
