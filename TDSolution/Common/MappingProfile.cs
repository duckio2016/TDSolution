using AutoMapper;
using TDSolution.DTOs;
using TDSolution.Models;

namespace TDSolution.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDetailDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<OrderCreateDto, Order>()
             .ForMember(dest => dest.Items, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<Order, OrderDetailDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}