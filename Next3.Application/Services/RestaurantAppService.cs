using AutoMapper;
using AutoMapper.QueryableExtensions;
using Next3.Application.EventSourcerNormalizers;
using Next3.Application.Interfaces;
using Next3.Application.ViewModels;
using Next3.Domain.Commands;
using Next3.Domain.Core.Bus;
using Next3.Domain.Interfaces;
using Next3.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace Next3.Application.Services
{
    public class RestaurantAppService : IRestaurantAppService
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public RestaurantAppService(IMapper mapper,
                                  IRestaurantRepository restaurantRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<RestaurantViewModel> GetAll()
        {
            return _restaurantRepository.GetAll().ProjectTo<RestaurantViewModel>();
        }

        public RestaurantViewModel GetById(Guid id)
        {
            return _mapper.Map<RestaurantViewModel>(_restaurantRepository.GetById(id));
        }

        public void Register(RestaurantViewModel restaurantViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewRestaurantCommand>(restaurantViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(RestaurantViewModel restaurantViewModel)
        {
            var updateCommand = _mapper.Map<UpdateRestaurantCommand>(restaurantViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveRestaurantCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<RestaurantHistoryData> GetAllHistory(Guid id)
        {
            return RestaurantHistory.ToJavaScriptRestaurantHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
