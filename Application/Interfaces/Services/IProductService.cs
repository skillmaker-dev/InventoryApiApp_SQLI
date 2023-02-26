using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>IEnumerable of products.</returns>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Get all products by descending price.
        /// </summary>
        /// <returns>IEnumerable of products.</returns>
        IEnumerable<Product> GetAllProductsSortedByPriceDescending();

        /// <summary>
        /// Get all products in a specific category.
        /// </summary>
        /// <param name="category">Category we want to search in.</param>
        /// <returns>IEnumerable of products.</returns>
        IEnumerable<Product> GetAllProductsInCategory(string category);

        /// <summary>
        /// Get all products by name.
        /// </summary>
        /// <param name="name">Name of product we want to search for.</param>
        /// <returns>IEnumerable of products.</returns>
        IEnumerable<Product> GetAllProductByName(string name);

        /// <summary>
        /// Get all products that have a discount higher than the specified discount.
        /// </summary>
        /// <param name="discount"></param>
        /// <returns>IEnumerable of products.</returns>
        IEnumerable<Product> GetAllProductsWithDiscountHigherThan(int discount);

        /// <summary>
        /// Get a product by barcode
        /// </summary>
        /// <param name="barcode">Barcode of product we want to search for.</param>
        /// <returns>The product we are searching for, otherwise null if not found.</returns>
        Product? GetProductByBarcode(int barcode);

        /// <summary>
        /// Add a product to datasource.
        /// </summary>
        /// <param name="product">The product we want to add.</param>
        void AddProduct(Product product);

        /// <summary>
        /// Delete a product with a specific barcode.
        /// </summary>
        /// <param name="barcode">Barcode of the product we want to delete.</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        bool DeleteProductByBarcode(int barcode);

        /// <summary>
        /// Update a product with the specified barcode.
        /// </summary>
        /// <param name="product">Updated product we want to save.</param>
        /// <param name="barcode">Barcode of the product we want to update.</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        bool UpdateProduct(Product product, int barcode);

    }
}
