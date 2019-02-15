using AutoMapper;
using Next3.Application.ViewModels;
using Next3.Domain.Commands;

namespace Next3.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RestaurantViewModel, RegisterNewRestaurantCommand>()
                .ConstructUsing(r => new RegisterNewRestaurantCommand(r.Name, r.Description, r.IsActive, r.ExpertiseId));

            CreateMap<RestaurantViewModel, UpdateRestaurantCommand>()
                .ConstructUsing(r => new UpdateRestaurantCommand(r.Id, r.Name, r.Description, r.IsActive, r.ExpertiseId));
        }
    }
}
