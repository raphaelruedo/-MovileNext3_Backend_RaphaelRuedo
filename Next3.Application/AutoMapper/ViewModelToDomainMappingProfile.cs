﻿using AutoMapper;
using Next3.Application.ViewModels;
using Next3.Domain.Commands;
using Next3.Domain.Models;

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

        }
    }
}
