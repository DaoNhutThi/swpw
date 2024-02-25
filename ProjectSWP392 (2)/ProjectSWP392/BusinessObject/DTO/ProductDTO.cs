using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class ProductDTO
{
    [Required(ErrorMessage = "Product Name is required.")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Product Image is required.")]
    public string ProductImage { get; set; }

    [Required(ErrorMessage = "Product Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Product Price must be greater than 0.")]
    public double ProductPrice { get; set; }

    [Required(ErrorMessage = "Category ID is required.")]
    public int CategoryID { get; set; }

    [Required(ErrorMessage = "Product Quantity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Product Quantity must be greater than 0.")]
    public int ProductQuantity { get; set; }

    [Required(ErrorMessage = "Product Detail Description is required.")]
    [StringLength(500, ErrorMessage = "Product Detail Description cannot exceed 500 characters.")]
    public string ProductDetailDescription { get; set; }

    [Required(ErrorMessage = "Product Chipset is required.")]
    [StringLength(50, ErrorMessage = "Product Chipset cannot exceed 50 characters.")]
    public string ProductChipset { get; set; }

    [Required(ErrorMessage = "Product Internal Storage is required.")]
    [StringLength(50, ErrorMessage = "Product Internal Storage cannot exceed 50 characters.")]
    public string ProductStorageInternal { get; set; }

    [Required(ErrorMessage = "Product External Storage is required.")]
    [StringLength(50, ErrorMessage = "Product External Storage cannot exceed 50 characters.")]
    public string ProductStorageExternal { get; set; }

    [Required(ErrorMessage = "Product Battery Capacity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Product Battery Capacity must be greater than 0.")]
    public int ProductBatteryCapacity { get; set; }

    [Required(ErrorMessage = "Product Selfie Camera is required.")]
    [StringLength(50, ErrorMessage = "Product Selfie Camera cannot exceed 50 characters.")]
    public string ProductSelfieCamera { get; set; }

    [Required(ErrorMessage = "Product Main Camera is required.")]
    [StringLength(50, ErrorMessage = "Product Main Camera cannot exceed 50 characters.")]
    public string ProductMainCamera { get; set; }
}
}
