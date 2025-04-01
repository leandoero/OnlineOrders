namespace OnlineOrders.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Product Product { get; set; }
    }
}
