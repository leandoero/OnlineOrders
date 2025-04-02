using OnlineOrders.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace OnlineOrders.Models.DTO
{
    public class UpdateClientDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name has to be a maximum of 50 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Surname has to be a maximum of 50 characters")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Address has to be a maximum of 50 characters")]
        public string Address { get; set; }

        [MaxLength(255, ErrorMessage = "Description has to be a maximum of 255 characters")]
        public string? Description { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid OrderStatusId { get; set; }
    }
}
