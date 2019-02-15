using Next3.Domain.Core.Events;
using System;

namespace Next3.Domain.Events
{
    public class RestaurantUpdatedEvent : Event
    {
        public RestaurantUpdatedEvent(Guid id, string name, string description, bool isActive, Guid expertiseId)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            AggregateId = id;
            ExpertiseId = expertiseId;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool IsActive { get; private set; }

        public Guid ExpertiseId { get; set; }
    }
}
