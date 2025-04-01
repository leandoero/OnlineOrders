namespace OnlineOrders.Models.DTO
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderStatusId { get; set; }
    }
}
