using MediatR;
using Next3.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Next3.Domain.EventHandlers
{
    public class ProductEventHandler :
           INotificationHandler<ProductRegisteredEvent>,
           INotificationHandler<ProductUpdatedEvent>,
           INotificationHandler<ProductRemovedEvent>
    {
        public Task Handle(ProductUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProductRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProductRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
