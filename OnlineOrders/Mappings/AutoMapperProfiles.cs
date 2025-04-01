using AutoMapper;
using OnlineOrders.Models.Domain;
using OnlineOrders.Models.DTO;

namespace OnlineOrders.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, AddClientDto>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();
        }
    }
}
