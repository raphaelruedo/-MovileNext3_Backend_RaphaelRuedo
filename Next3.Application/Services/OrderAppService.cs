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
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public OrderAppService(IMapper mapper,
                                  IOrderRepository orderRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            return _orderRepository.GetAll().ProjectTo<OrderViewModel>();
        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public void Register(OrderViewModel orderViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewOrderCommand>(orderViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(OrderViewModel orderViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrderCommand>(orderViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveOrderCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<OrderHistoryData> GetAllHistory(Guid id)
        {
            return OrderHistory.ToJavaScriptOrderHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
