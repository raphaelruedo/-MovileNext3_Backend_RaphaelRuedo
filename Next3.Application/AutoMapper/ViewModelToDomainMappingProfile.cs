using AutoMapper;
using Next3.Application.ViewModels;
using Next3.Domain.Commands;
using Next3.Domain.Models;
using System.Collections.Generic;

namespace Next3.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Restaurants
            CreateMap<RestaurantViewModel, RegisterNewRestaurantCommand>()
                .ConstructUsing(r => new RegisterNewRestaurantCommand(r.Name, r.Description, r.IsActive, r.ExpertiseId, Mapper.Map<AddressViewModel, Address>(r.Address)));

            CreateMap<RestaurantViewModel, UpdateRestaurantCommand>()
                .ConstructUsing(r => new UpdateRestaurantCommand(r.Id, r.Name, r.Description, r.IsActive, r.ExpertiseId));

            //PRoducts
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(product => new RegisterNewProductCommand(product.Name, product.Description, product.Price, product.RestaurantId, product.CategoryId));

            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(product => new UpdateProductCommand(product.Id, product.Name, product.Description, product.Price, product.RestaurantId, product.CategoryId));


            //Order
            CreateMap<OrderViewModel, RegisterNewOrderCommand>()
               .ConstructUsing(order => new RegisterNewOrderCommand(order.Observation, Mapper.Map<List<OrderItemViewModel>, List<OrderItem>>(order.OrderItens), order.UserId, Mapper.Map<AddressViewModel, Address>(order.Address), order.OrderStatusId));

            CreateMap<OrderViewModel, UpdateOrderCommand>()
                .ConstructUsing(order => new UpdateOrderCommand(order.Id, order.Observation, Mapper.Map<List<OrderItemViewModel>, List<OrderItem>>(order.OrderItens), order.UserId, Mapper.Map<AddressViewModel, Address>(order.Address), order.OrderStatusId));

        }
    }
}
