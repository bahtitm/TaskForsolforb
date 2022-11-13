using AutoMapper;
using WebApp.Application.Modules.Commons.OrderItems.Commands.CreateOrderItem;
using WebApp.Application.Modules.Commons.OrderItems.Commands.UpdateOrderItem;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.OrderItems.MappingProfile
{
    public class OrderItemMappingProfile : Profile
    {
        public OrderItemMappingProfile()
        {
            CreateMap<CreateOrderItemCommand, OrderItem>();
            CreateMap<UpdateOrderItemCommand, OrderItem>();

            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
