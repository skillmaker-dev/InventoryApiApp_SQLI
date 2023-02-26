using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    /// <summary>
    /// Data transfer object to insert barcode in body.
    /// </summary>
    public class BarcodeDto
    {
        [Required]
        public int Barcode { get; set; }
    }
}
