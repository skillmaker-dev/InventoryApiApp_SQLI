using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;
using InventoryApi.Common;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("inventory")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Product service class.
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// Product controller constructor.
        /// </summary>
        /// <param name="productService">Product service instance that implements the IProductService to be injected.</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all products from data source (Example: GET: inventory/items)
        /// </summary>
        /// <returns>List of all products.</returns>
        [HttpGet("items")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();

            return Ok(products);
        }

        /// <summary>
        /// Get all products by descending price (Example: GET: inventory/item/sort)
        /// </summary>
        /// <returns>List of all products sorted by descending price.</returns>
        [HttpGet("item/sort")]
        public ActionResult<IEnumerable<Product>> GetAllProductsByDescendingPrice()
        {
            var products = _productService.GetAllProductsSortedByPriceDescending();

            return Ok(products);
        }

        /// <summary>
        /// Get products by specified query. (Example: GET: inventory/item/{query})
        /// </summary>
        /// <param name="barcode">Barcode of product.</param>
        /// <param name="category">Category name of product.</param>
        /// <param name="discount">Discount of product.</param>
        /// <param name="name">Name of product.</param>
        /// <returns>List of products based on query.</returns>
        [HttpGet("item/query")]
        public ActionResult<IEnumerable<Product>> GetProductsByQuery([FromQuery] int? barcode, [FromQuery] string? category, [FromQuery] int? discount, [FromQuery] string? name)
        {
            var products = new List<Product>();

            if (barcode.HasValue)
            {
                var product = _productService.GetProductByBarcode(barcode.Value);

                //We check if product exists.
                if (product is not null)
                    products.Add(product);
            }
            else if (!string.IsNullOrEmpty(category))
            {
                products = _productService.GetAllProductsInCategory(category).ToList();
            }
            else if (discount.HasValue)
            {
                products = _productService.GetAllProductsWithDiscountHigherThan(discount.Value).ToList();
            }
            else if (!string.IsNullOrEmpty(name))
            {
                products = _productService.GetAllProductByName(name).ToList();
            }

            return Ok(products);
        }

        /// <summary>
        /// Update a product. (Example PUT: inventory/item/{barcode})
        /// </summary>
        /// <param name="barcode">Barcode of product to update.</param>
        /// <param name="product">Updated product.</param>
        /// <returns>Returns 204 status code if success, otherwise 404.</returns>
        [HttpPut("item/{barcode}")]
        public IActionResult UpdateProduct([FromRoute] int barcode, [FromBody] Product product)
        {
            var productToUpdate = _productService.GetProductByBarcode(barcode);

            //We check if product exists.
            if (productToUpdate is null)
                return NotFound();

            if (_productService.UpdateProduct(product, barcode))
                return NoContent();

            // return internal server error status code when we can't update product.
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Delete product by barcode (Example: DELETE: inventory/item ).
        /// </summary>
        /// <param name="barcodeDto">Barcode of product to delete.</param>
        /// <returns>Returns 204 status code if success, otherwise 404.</returns>
        [HttpDelete("item")]
        public IActionResult DeleteProductByBarcode(BarcodeDto barcodeDto)
        {
            var productToUpdate = _productService.GetProductByBarcode(barcodeDto.Barcode);

            //We check if product exists.
            if (productToUpdate is null)
                return NotFound();

            if (_productService.DeleteProductByBarcode(barcodeDto.Barcode))
                return NoContent();

            // return internal server error status code when we can't delete product.
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Add product (Example: POST: inventory/item )
        /// </summary>
        /// <param name="productDto">Product we want to add.</param>
        /// <returns>Returns an URL to get the created product.</returns>
        [HttpPost("item")]
        public IActionResult AddProduct(ProductDto productDto)
        {
            if (productDto is null)
                return BadRequest();

            var product = productDto.Adapt<Product>();

            // We check if product was successfully mapped else we return an internal server error.
            if (product is not null)
            {
                var existingProduct = _productService.GetProductByBarcode(product.Barcode);

                if (existingProduct is not null)
                    return BadRequest(CommonConstants.ErrorMessages.PRODUCT_ALREADY_EXISTS);

                _productService.AddProduct(product);

                // return a 201 status code when successfull.
                return CreatedAtAction(nameof(GetProductsByQuery), new { barcode = product.Barcode }, product);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
