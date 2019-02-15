using MediatR;
using Next3.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Next3.Domain.EventHandlers
{
    public class RestaurantEventHandler :
          INotificationHandler<RestaurantRegisteredEvent>,
          INotificationHandler<RestaurantUpdatedEvent>,
          INotificationHandler<RestaurantRemovedEvent>
    {
        public Task Handle(RestaurantUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RestaurantRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RestaurantRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
