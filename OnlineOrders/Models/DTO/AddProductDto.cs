using System.ComponentModel.DataAnnotations;

namespace OnlineOrders.Models.DTO
{
    public class AddProductDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name has to be a maximum of 50 characters")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description has to be a maximum of 255 characters")]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}

