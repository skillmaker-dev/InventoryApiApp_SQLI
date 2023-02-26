using Domain.Entities;

namespace Infrastructure.Data
{
    // our in memory data source.
    public static class DataSource
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Name = "SAMSUNG GALAXY S21 Ultra", Category ="GSM", Price = 10000 , Discount = 5, Quantity = 100, Barcode = 12546358 },
            new Product { Name = "REFRIGERATEUR SAMSUNG NO-FROST", Category ="REFRIGIRATEUR", Price = 7000 , Discount = 10, Quantity = 20, Barcode = 12454784 },
            new Product { Name = "Easy T-Shirt Homme", Category ="FASHION", Price = 100 , Discount = 1, Quantity = 63, Barcode = 25458778 },
            new Product { Name = "New Balance Basket Homme", Category ="FASHION", Price = 300 , Discount = 5, Quantity = 15, Barcode = 457887558 },
            new Product { Name = "L'Oréal Paris Fond de Teint", Category ="BEAUTE", Price = 600 , Discount = 4, Quantity = 70, Barcode = 987588 }
        };
    }
}
