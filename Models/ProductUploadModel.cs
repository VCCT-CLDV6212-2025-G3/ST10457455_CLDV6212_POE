using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ABC_Retail_CloudApp.Models
{
    public class ProductUploadModel
    {
        [Required(ErrorMessage = "Product name is required")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        // ✅ Only ONE Display attribute here
        [Required(ErrorMessage = "Please upload an image")]
        [Display(Name = "Upload Product Image")]
        public IFormFile? ProductImage { get; set; }
    }
}
