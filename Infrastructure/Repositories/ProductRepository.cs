using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository interface.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Add a product to datasource.
        /// </summary>
        /// <param name="product">Product we want to add.</param>
        public void AddProduct(Product product)
        {
            Data.DataSource.Products.Add(product);
        }

        /// <summary>
        /// Delete a product from datasource.
        /// </summary>
        /// <param name="barcode">Barcode of product we want to delete</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        public bool DeleteProduct(int barcode)
        {
            var product = GetProductByBarcode(barcode);

            if (product is null)
                return false;

            return Data.DataSource.Products.Remove(product);
        }

        /// <summary>
        /// Get all products from datasource.
        /// </summary>
        /// <returns>IEnumerable of products.</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return Data.DataSource.Products;
        }

        /// <summary>
        /// Get a product by barcode.
        /// </summary>
        /// <param name="barcode">Barcode of product</param>
        /// <returns>Product we are looking for.</returns>
        public Product? GetProductByBarcode(int barcode)
        {
            var product = Data.DataSource.Products.FirstOrDefault(p => p.Barcode == barcode);

            return product;
        }

        /// <summary>
        /// Update a product in datasource.
        /// </summary>
        /// <param name="product">Updated product.</param>
        /// <param name="barcode">Barcode of the product we want to update</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        public bool UpdateProduct(Product product, int barcode)
        {
            var productToUpdate = GetProductByBarcode(barcode);

            if (productToUpdate is null)
                return false;

            productToUpdate.Barcode = product.Barcode;
            productToUpdate.Discount = product.Discount;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
            productToUpdate.Name = product.Name;
            productToUpdate.Category = product.Category;

            return true;
        }
    }
}
