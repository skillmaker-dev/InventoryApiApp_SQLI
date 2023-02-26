using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    /// <summary>
    /// Our data transfer object based on the Product entity.
    /// </summary>
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public int Discount { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Barcode { get; set; }
    }
}
