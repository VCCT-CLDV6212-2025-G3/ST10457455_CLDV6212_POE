using System.ComponentModel.DataAnnotations;

namespace ABC_Retail_CloudApp.Models
{
    public class ProductSQL
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        public string? Category { get; set; }

        public decimal? Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
