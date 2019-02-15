﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Next3.Application.Interfaces;
using Next3.Application.Services;
using Next3.Domain.CommandHandlers;
using Next3.Domain.Commands;
using Next3.Domain.Core.Bus;
using Next3.Domain.Core.Events;
using Next3.Domain.Core.Notifications;
using Next3.Domain.EventHandlers;
using Next3.Domain.Events;
using Next3.Domain.Interfaces;
using Next3.Infra.CrossCutting.Bus;
using Next3.Infra.Data.Context;
using Next3.Infra.Data.EventSourcing;
using Next3.Infra.Data.Repository;
using Next3.Infra.Data.Repository.EventSourcing;
using Next3.Infra.Data.UoW;

namespace Next3.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IRestaurantAppService, RestaurantAppService>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<RestaurantRegisteredEvent>, RestaurantEventHandler>();
            services.AddScoped<INotificationHandler<RestaurantUpdatedEvent>, RestaurantEventHandler>();
            services.AddScoped<INotificationHandler<RestaurantRemovedEvent>, RestaurantEventHandler>();

            services.AddScoped<IRequestHandler<RegisterNewRestaurantCommand, Unit>, RestaurantCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateRestaurantCommand, Unit>, RestaurantCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveRestaurantCommand, Unit>, RestaurantCommandHandler>();

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Next3Context>();

            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}
