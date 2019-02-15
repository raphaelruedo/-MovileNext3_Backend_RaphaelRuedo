using Next3.Domain.Core.Events;
using System;

namespace Next3.Domain.Events
{
    public  class RestaurantRemovedEvent : Event
    {
        public RestaurantRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
