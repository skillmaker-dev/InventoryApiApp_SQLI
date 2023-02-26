using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    /// <summary>
    /// Product repository interface.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products from datasource.
        /// </summary>
        /// <returns>IEnumerable of products.</returns>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Get a product by barcode.
        /// </summary>
        /// <param name="barcode">Barcode of product</param>
        /// <returns>Product we are looking for.</returns>
        Product? GetProductByBarcode(int barcode);

        /// <summary>
        /// Add a product to datasource.
        /// </summary>
        /// <param name="product">Product we want to add.</param>
        void AddProduct(Product product);

        /// <summary>
        /// Delete a product from datasource.
        /// </summary>
        /// <param name="barcode">Barcode of product we want to delete</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        bool DeleteProduct(int barcode);

        /// <summary>
        /// Update a product in datasource.
        /// </summary>
        /// <param name="product">Updated product we want to save.</param>
        /// <param name="barcode">Barcode of the product we want to update</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        bool UpdateProduct(Product product, int barcode);
    }
}
