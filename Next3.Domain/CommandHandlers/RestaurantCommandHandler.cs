﻿using MediatR;
using Next3.Domain.Commands;
using Next3.Domain.Core.Bus;
using Next3.Domain.Core.Notifications;
using Next3.Domain.Events;
using Next3.Domain.Interfaces;
using Next3.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Next3.Domain.CommandHandlers
{
    public class RestaurantCommandHandler : CommandHandler,
         IRequestHandler<RegisterNewRestaurantCommand>,
         IRequestHandler<UpdateRestaurantCommand>,
         IRequestHandler<RemoveRestaurantCommand>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMediatorHandler Bus;

        public RestaurantCommandHandler(IRestaurantRepository restaurantRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _restaurantRepository = restaurantRepository;
            Bus = bus;
        }

        public Task<Unit> Handle(RegisterNewRestaurantCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            var restaurant = new Restaurant(Guid.NewGuid(), message.Name, message.Description, message.IsActive, message.ExpertiseId, message.AddressId);

            if (_restaurantRepository.GetByName(restaurant.Name) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um restaurant com este nome."));
                return Unit.Task;
            }

            _restaurantRepository.Add(restaurant);

            if (Commit())
            {
                Bus.RaiseEvent(new RestaurantRegisteredEvent(restaurant.Id, restaurant.Name, restaurant.Description, restaurant.IsActive, restaurant.ExpertiseId, message.AddressId));
            }

            return Unit.Task;
        }

        public Task<Unit> Handle(UpdateRestaurantCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            var restaurant = new Restaurant(message.Id, message.Name, message.Description, message.IsActive, message.ExpertiseId, message.AddressId);
            var existingRestaurant = _restaurantRepository.GetByName(restaurant.Name);

            if (existingRestaurant != null && existingRestaurant.Id != restaurant.Id)
            {
                if (!existingRestaurant.Equals(restaurant))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um restaurante com este nome"));
                    return Unit.Task;
                }
            }

            _restaurantRepository.Update(restaurant);

            if (Commit())
            {
                Bus.RaiseEvent(new RestaurantUpdatedEvent(restaurant.Id, restaurant.Name, restaurant.Description, restaurant.IsActive, restaurant.ExpertiseId));
            }

            return Unit.Task;
        }

        public Task<Unit> Handle(RemoveRestaurantCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            _restaurantRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new RestaurantRemovedEvent(message.Id));
            }

            return Unit.Task;
        }

        public void Dispose()
        {
            _restaurantRepository.Dispose();
        }
    }
}
