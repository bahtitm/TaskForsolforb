using AutoMapper;
using WebApp.Application.Modules.Commons.Orders.Commands.CreateOrder;
using WebApp.Application.Modules.Commons.Orders.Commands.UpdateOrder;
using WebApp.Application.Modules.Commons.Orders.Dtos;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Orders.MappingProfile
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();

            CreateMap<Order, OrderDto>();
        }
    }
}
