using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    /// <summary>
    /// The implementation of our product service.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        /// <summary>
        /// Construtor to inject our instances.
        /// </summary>
        /// <param name="repository">An instance that implements the IProductRepository interface.</param>
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Add a product to datasource.
        /// </summary>
        /// <param name="product">The product we want to add.</param>
        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }


        /// <summary>
        /// Delete a product with a specific barcode.
        /// </summary>
        /// <param name="barcode">Barcode of the product we want to delete.</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        public bool DeleteProductByBarcode(int barcode)
        {
            return _repository.DeleteProduct(barcode);
        }


        /// <summary>
        /// Get all products by name.
        /// </summary>
        /// <param name="name">Name of product we want to search for.</param>
        /// <returns>IEnumerable of products.</returns>
        public IEnumerable<Product> GetAllProductByName(string name)
        {
            var products = _repository.GetAllProducts();

            var productsByName = products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return productsByName;
        }


        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>IEnumerable of products.</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }


        /// <summary>
        /// Get all products in a specific category.
        /// </summary>
        /// <param name="category">Category we want to search in.</param>
        /// <returns>IEnumerable of products.</returns>
        public IEnumerable<Product> GetAllProductsInCategory(string category)
        {
            var products = _repository.GetAllProducts();

            var productsByCategory = products.Where(p => p.Category.ToLower().Equals(category.ToLower()));

            return productsByCategory;
        }


        /// <summary>
        /// Get all products by descending price.
        /// </summary>
        /// <returns>IEnumerable of products.</returns>
        public IEnumerable<Product> GetAllProductsSortedByPriceDescending()
        {
            return _repository.GetAllProducts().OrderByDescending(p => p.Price);
        }


        /// <summary>
        /// Get all products that have a discount higher than the specified discount.
        /// </summary>
        /// <param name="discount"></param>
        /// <returns>IEnumerable of products.</returns>
        public IEnumerable<Product> GetAllProductsWithDiscountHigherThan(int discount)
        {
            var products = _repository.GetAllProducts();

            var filtredProducts = products.Where(p => p.Discount > discount);

            return filtredProducts;
        }


        /// <summary>
        /// Get a product by barcode
        /// </summary>
        /// <param name="barcode">Barcode of product we want to search for.</param>
        /// <returns>The product we are searching for, otherwise null if not found.</returns>
        public Product? GetProductByBarcode(int barcode)
        {
            return _repository.GetProductByBarcode(barcode);
        }


        /// <summary>
        /// Update a product with the specified barcode.
        /// </summary>
        /// <param name="product">Updated product we want to save.</param>
        /// <param name="barcode">Barcode of the product we want to update.</param>
        /// <returns>True if operation successful otherwise return false.</returns>
        public bool UpdateProduct(Product product, int barcode)
        {
            return _repository.UpdateProduct(product, barcode);
        }
    }
}
