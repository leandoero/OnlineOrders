﻿namespace OnlineOrders.Models.DTO
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
